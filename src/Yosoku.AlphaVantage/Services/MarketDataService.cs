using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using Yosoku.AlphaVantage.Models;

[assembly: InternalsVisibleTo("Yosoku.AlphaVantage.Tests")]

namespace Yosoku.AlphaVantage.Services;

public interface IMarketDataService
{
    Task<List<MonthlyMarketData>> GetMarketDataAsync(string symbol, CancellationToken token);
}

public class MarketDataService(IAlphaVantageClient client, ILogger<MarketDataService> logger) : IMarketDataService
{
    public async Task<List<MonthlyMarketData>> GetMarketDataAsync(string symbol, CancellationToken token)
    {
        var monthlyTask = client.TimeSeriesMonthlyAsync(symbol, token);
        var dailyTask = client.TimeSeriesDailyAsync(symbol, token);
        var incomeTask = client.GetIncomeStatements(symbol, token);
        var balanceTask = client.GetBalanceSheets(symbol, token);

        await Task.WhenAll(monthlyTask, dailyTask, incomeTask, balanceTask);

        var monthlyData = await monthlyTask;
        var dailyData = await dailyTask;
        var incomeStatement = await incomeTask;

        // 1. Pre-process and Sort data once
        var sortedMonthly = monthlyData?.MonthlyTimeSeries?
            .OrderBy(x => x.Key)
            .ToList() ?? [];

        var sortedDaily = dailyData?.DailyTimeSeries?
            .OrderBy(x => x.Key)
            .Select(x => (Date: x.Key, Price: x.Value.AdjustedClose))
            .ToList() ?? [];

        var sortedReports = incomeStatement?.QuarterlyReports?
            .Where(r => r.NetIncome > 0)
            .OrderBy(r => r.FiscalDateEnding)
            .ToList() ?? [];

        var results = new List<MonthlyMarketData>();

        // 2. Single pass iteration
        for (int i = 0; i < sortedMonthly.Count; i++)
        {
            try
            {
                var entry = sortedMonthly[i];
                var monthDate = entry.Key;
                var currentPrice = entry.Value.AdjustedClose;

                // --- Find the index ONCE per month ---
                int dailyIndex = sortedDaily.BinarySearch(
                    new(monthDate, 0f),
                    Comparer<(DateOnly Date, float Price)>.Create((a, b) => a.Date.CompareTo(b.Date)));

                if (dailyIndex < 0)
                    dailyIndex = ~dailyIndex; // Convert to correct index if not found
                if (dailyIndex >= sortedDaily.Count) 
                    dailyIndex = sortedDaily.Count - 1;

                // Calculate PE Ratio
                float peRatio = 0f;
                var report = sortedReports
                    .Where(r => r.FiscalDateEnding <= monthDate)
                    .OrderByDescending(r => r.FiscalDateEnding)
                    .FirstOrDefault();

                if (report != null && report.NetIncome > 0)
                {
                    peRatio = currentPrice / report.NetIncome.Value;
                }
                else
                {
                    throw new InvalidOperationException($"Not enough data to calculate pe ratio for {monthDate}");
                }

                // Calculate Future Return
                float futureReturn = 0f;
                if (i + 3 < sortedMonthly.Count)
                {
                    var futureQuote = sortedMonthly[i + 3];
                    if (futureQuote.Value.AdjustedClose > 0)
                    {
                        futureReturn = (futureQuote.Value.AdjustedClose - currentPrice) / currentPrice * 100;
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Not enough future data to calculate 3-month return for {monthDate}");
                }

                results.Add(new MonthlyMarketData
                {
                    Date = monthDate,
                    PeRatio = peRatio,
                    FutureTotalReturn = futureReturn,
                    Sma50 = CalculateSma(sortedDaily, dailyIndex, 50),
                    Sma200 = CalculateSma(sortedDaily, dailyIndex, 200)
                });
            }
            catch (Exception e)
            {
            }
        }


        return results;
    }

    private static float CalculateSma(
        List<(DateOnly Date, float AdjustedClose)> sortedDaily,
        int index,
        int length)
    {
        // Check if we have enough historical data points
        // We need 'length' points, so the current index must be at least length - 1
        if (index < length - 1)
        {
            throw new InvalidOperationException(
                $"Insufficient data to calculate {length}-day SMA. " +
                $"Current index is {index}, but need at least {length - 1}.");
        }

        float sum = 0f;
        for (int i = 0; i < length; i++)
        {
            sum += sortedDaily[index - i].AdjustedClose;
        }

        return sum / length;
    }
}