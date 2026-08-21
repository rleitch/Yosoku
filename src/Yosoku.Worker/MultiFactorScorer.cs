using Yosoku.AlphaVantage;
using Yosoku.AlphaVantage.Models;
using Yosoku.Worker.Interfaces;
using Yosoku.Worker.Models;

namespace Yosoku.Worker;

public class MultiFactorScorer(IAlphaVantageClient client, ILogger<MultiFactorScorer> logger) : IMultiFactorScorer
{
    public async Task<List<ScoredStock>> GetTopStocksAsync(List<string> symbols, CancellationToken cancellationToken)
    {
        var tasks = symbols.Select(s => FetchAndParseDataAsync(s, cancellationToken)).ToList();
        var rawResults = await Task.WhenAll(tasks);

        var rawData = rawResults.Where(x => x != null).ToList();
        if (rawData.Count == 0)
        {
            return [];
        }

        // 2. Pre-sort for O(N log N) ranking instead of O(N^2)
        var qualityList = rawData.Select(x => x.QualityRaw).OrderBy(x => x).ToList();
        var profitList = rawData.Select(x => x.ProfitRaw).OrderBy(x => x).ToList();
        var momentumList = rawData.Select(x => x.MomentumRaw).OrderBy(x => x).ToList();

        // 3. Score and Rank
        var results = new List<ScoredStock>();
        foreach (var item in rawData)
        {
            var stock = new ScoredStock { Symbol = item.Symbol };

            // Use Binary Search to find rank in O(log N)
            stock.FactorScores["Quality"] = CalculatePercentile(item.QualityRaw, qualityList, isHigherBetter: false) * 100;
            stock.FactorScores["Profitability"] = CalculatePercentile(item.ProfitRaw, profitList, isHigherBetter: true) * 100;
            stock.FactorScores["Momentum"] = CalculatePercentile(item.MomentumRaw, momentumList, isHigherBetter: true) * 100;

            stock.TotalScore = (stock.FactorScores["Quality"] * 0.4F) +
                                (stock.FactorScores["Profitability"] * 0.3F) +
                                (stock.FactorScores["Momentum"] * 0.3F);

            results.Add(stock);
        }

        return [.. results.OrderByDescending(x => x.TotalScore)];
    }

    private async Task<StockRawData?> FetchAndParseDataAsync(string symbol, CancellationToken ct)
    {
        try
        {
            var price = await client.TimeSeriesMonthlyAsync(symbol, ct);

            if (price?.MonthlyTimeSeries == null || price.MonthlyTimeSeries.Count < 12)
            {
                return null;
            }

            var income = await client.GetIncomeStatements(symbol, ct);
            var balance = await client.GetBalanceSheets(symbol, ct);

            // 1. Fetch 5 quarters instead of 4 (1 Current + 4 Past)
            var allIncome = income.QuarterlyReports
                .OrderByDescending(r => r.FiscalDateEnding)
                .Take(5)
                .Select(i => new
                {
                    Ebit = GetBestEbit(i),
                    i.TotalRevenue
                })
                .Where(i => i.Ebit.HasValue && i.TotalRevenue.GetValueOrDefault(0) != 0)
                .Select(i => new SmallIncomeStatement(i.Ebit!.Value, i.TotalRevenue!.Value))
                .ToList();

            if (allIncome.Count < 5) return null;

            var current = allIncome[0];
            var past = allIncome.Skip(1).ToList();

            float currentMargin = current.Ebit / current.TotalRevenue;

            float avgPastMargin = past.Average(i => i.Ebit / i.TotalRevenue);

            float p = 0;
            if (avgPastMargin != 0)
            {
                p = currentMargin / avgPastMargin;
            }
            else
            {
                p = currentMargin;
            }

            var latestBalanceSheets = balance.QuarterlyReports
                .OrderByDescending(r => r.FiscalDateEnding)
                .Take(4)
                .Where(b => b.TotalLiabilities.HasValue && b.TotalShareholderEquity.GetValueOrDefault(0) != 0)
                .Select(b => new SmallBalanceSheet(
                    b.TotalLiabilities!.Value,
                    b.TotalShareholderEquity!.Value))
                .ToList();

            if (latestBalanceSheets.Count < 3)
            {
                return null;
            }

            var q = latestBalanceSheets
                .Average(r => r.TotalLiabilities / r.TotalShareholderEquity);

            float m = CalculateSmaMomentum(price.MonthlyTimeSeries);

            return new StockRawData { Symbol = symbol, QualityRaw = q, ProfitRaw = p, MomentumRaw = m };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error processing {Symbol}", symbol);
            return null;
        }
    }

    private static float CalculatePercentile(float value, List<float> sortedValues, bool isHigherBetter)
    {
        if (sortedValues.Count == 0)
        {
            return 0;
        }

        int index = sortedValues.BinarySearch(value);
        if (index < 0)
        {
            index = ~index;
        }

        float count = isHigherBetter
            ? index
            : (sortedValues.Count - index);

        return count / sortedValues.Count;
    }

    private static float? GetBestEbit(IncomeStatement i)
    {
        if (i.Ebit.HasValue)
        {
            return i.Ebit.Value;
        }

        if (i.OperatingIncome.HasValue)
        {
            return i.OperatingIncome.Value;
        }

        if (i.Ebitda.HasValue)
        {
            return i.Ebitda.Value;
        }

        return i.NetIncome;
    }

    private record SmallBalanceSheet(float TotalLiabilities, float TotalShareholderEquity);

    private record SmallIncomeStatement(float Ebit, float TotalRevenue);

    private static float CalculateSmaMomentum(
    Dictionary<DateOnly, Quote> monthlySeries,
    int shortPeriod = 6,
    int longPeriod = 12)
    {

        if (monthlySeries == null || monthlySeries.Count < longPeriod)
        {
            return 0f;
        }

        var ordered = monthlySeries
            .OrderByDescending(kvp => kvp.Key)
            .Take(longPeriod)
            .ToList();

        var shortSma = ordered.Take(shortPeriod).Average(kvp => kvp.Value.AdjustedClose);
        var longSma = ordered.Take(longPeriod).Average(kvp => kvp.Value.AdjustedClose);

        return (shortSma - longSma) / (longSma == 0 ? 1 : longSma);
    }
}