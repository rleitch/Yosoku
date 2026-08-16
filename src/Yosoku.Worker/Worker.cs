using Microsoft.EntityFrameworkCore;
using Yosoku.AlphaVantage;
using Yosoku.AlphaVantage.Models;
using Yosoku.Data;
using Yosoku.Data.Entities;

namespace Yosoku.Worker;

public class Worker(
    ILogger<Worker> logger,
    AlphaVantageClient alphaVantageClient,
    IDbContextFactory<YosokuContext> DbFactory)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            using var context = await DbFactory.CreateDbContextAsync(stoppingToken);

            var etfProfile = await alphaVantageClient.GetEtfProfile("VTI", stoppingToken);
            foreach (var holding in etfProfile.Holdings)
            {
                try
                {
                    var monthlyData = await alphaVantageClient.TimeSeriesMonthlyAsync(holding.Symbol, stoppingToken);
                    var dailyData = await alphaVantageClient.TimeSeriesDailyAsync(holding.Symbol, stoppingToken);
                    var incomeStatementData = await alphaVantageClient.GetIncomeStatements(holding.Symbol, stoppingToken);
                    var balanceSheetData = await alphaVantageClient.GetBalanceSheets(holding.Symbol, stoppingToken);

                    var monthlyDataDesc = monthlyData.MonthlyTimeSeries!
                        .OrderByDescending(x => x.Key)
                        .ToList();

                    var rsiValues = CalculateRSI(dailyData.DailyTimeSeries!);

                    var existingRecords = await context.Records
                        .Where(r => r.Ticker == monthlyData.MetaData.Symbol)
                        .ToDictionaryAsync(r => r.Date, stoppingToken);

                    foreach (var entry in monthlyDataDesc)
                    {
                        try
                        {
                            var momentum = CalculateMomentumAtDate(monthlyDataDesc, entry.Key, 3);
                            if (double.IsNaN(momentum))
                            {
                                continue;
                            }

                            rsiValues.TryGetValue(entry.Key, out double rsiValue);

                            var sortedQuarterlyIncomeStatements = incomeStatementData.QuarterlyReports
                                .Where(r => r.FiscalDateEnding <= entry.Key)
                                .OrderByDescending(x => x.FiscalDateEnding)
                                .ToList();

                            var latestIncomeStatement = sortedQuarterlyIncomeStatements.FirstOrDefault();

                            var sortedQuarterlyBalanceSheets = balanceSheetData.QuarterlyReports
                                .Where(r => r.FiscalDateEnding <= entry.Key)
                                .OrderByDescending(x => x.FiscalDateEnding)
                                .ToList();

                            var latestBalanceSheet = sortedQuarterlyBalanceSheets.FirstOrDefault();

                            var peRatio = CalculatePERatio(
                                entry.Value.AdjustedClose,
                                latestIncomeStatement?.NetIncome ?? 0,
                                latestBalanceSheet?.CommonStockSharesOutstanding ?? 0);

                            double sma50 = CalculateSMA(dailyData.DailyTimeSeries!, entry.Key, 50);
                            double sma200 = CalculateSMA(dailyData.DailyTimeSeries!, entry.Key, 200);

                            if (existingRecords.TryGetValue(entry.Key, out var existingRecord))
                            {
                                if (Math.Abs(existingRecord.Score - momentum) > 0.0001)
                                {
                                    existingRecord.Score = momentum;
                                }

                                if (Math.Abs(existingRecord.Rsi - rsiValue) > 0.0001)
                                {
                                    existingRecord.Rsi = rsiValue;
                                }

                                if (Math.Abs(existingRecord.PeRatio - peRatio) > 0.0001)
                                {
                                    existingRecord.PeRatio = peRatio;
                                }

                                if (Math.Abs(existingRecord.Sma50 - sma50) > 0.0001)
                                {
                                    existingRecord.Sma50 = sma50;
                                }

                                if (Math.Abs(existingRecord.Sma200 - sma200) > 0.0001)
                                {
                                    existingRecord.Sma200 = sma200;
                                }
                            }
                            else
                            {
                                context.Records.Add(new Record(
                                    holding.Symbol,
                                    entry.Key,
                                    momentum,
                                    rsiValue,
                                    peRatio,
                                    sma50,
                                    sma200));
                            }
                        }
                        catch (Exception)
                        {
                            logger.LogError($"An error occurred while processing data for {holding.Symbol} {entry.Key}.");
                        }
                    }
                }
                catch (Exception)
                {
                    logger.LogError($"An error occurred while processing data for {holding.Symbol}.");
                }
                await context.SaveChangesAsync(stoppingToken);
            }
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "An error occurred while executing the worker.");
        }
        finally
        {
            logger.LogInformation("Done");
        }
    }

    public static double CalculateMomentumAtDate(
        List<KeyValuePair<DateOnly, TimeSeries>> sortedEntries,
        DateOnly targetDate,
        int periodsAgo)
    {
        var index = sortedEntries.FindIndex(x => x.Key == targetDate);

        if (index == -1 || index + periodsAgo >= sortedEntries.Count)
        {
            return double.NaN;
        }

        var currentPrice = sortedEntries[index].Value.AdjustedClose;
        var pricePast = sortedEntries[index + periodsAgo].Value.AdjustedClose;

        return ((currentPrice - pricePast) / pricePast) * 100;
    }

    public static Dictionary<DateOnly, double> CalculateRSI(
    Dictionary<DateOnly, TimeSeries> sortedEntries,
    int period = 14)
    {
        var rsiResults = new Dictionary<DateOnly, double>();
        var ascending = sortedEntries.OrderBy(x => x.Key).ToList();

        if (ascending.Count <= period)
        {
            return rsiResults;
        }

        double avgGain = 0;
        double avgLoss = 0;

        for (int i = 1; i < ascending.Count; i++)
        {
            double change = ascending[i].Value.AdjustedClose - ascending[i - 1].Value.AdjustedClose;
            double gain = Math.Max(0, change);
            double loss = Math.Max(0, -change);

            if (i <= period)
            {
                avgGain += gain / period;
                avgLoss += loss / period;
                if (i == period)
                {
                    double rs = avgLoss == 0 ? 100 : avgGain / avgLoss;
                    rsiResults[ascending[i].Key] = 100 - (100 / (1 + rs));
                }
            }
            else
            {
                avgGain = (avgGain * (period - 1) + gain) / period;
                avgLoss = (avgLoss * (period - 1) + loss) / period;
                double rs = avgLoss == 0 ? 100 : avgGain / avgLoss;
                rsiResults[ascending[i].Key] = 100 - (100 / (1 + rs));
            }
        }
        return rsiResults;
    }

    public static double CalculatePERatio(double currentPrice, double netIncome, double sharesOutstanding)
    {
        if (sharesOutstanding <= 0 || netIncome <= 0)
        {
            throw new ArgumentException("Shares outstanding and net income must be greater than zero to calculate P/E ratio.");
        }

        double eps = netIncome / sharesOutstanding;
        return currentPrice / eps;
    }
    public static double CalculateSMA(
        Dictionary<DateOnly, TimeSeries> dailyData,
        DateOnly targetDate,
        int period)
    {
        var relevantData = dailyData
            .Where(x => x.Key <= targetDate)
            .OrderBy(x => x.Key)
            .ToList();

        if (relevantData.Count < period)
        {
            throw new ArgumentException($"Not enough data to calculate SMA for {period} periods on {targetDate}. Available data points: {relevantData.Count}.");
        }

        var lastEntries = relevantData.TakeLast(period).ToList();
        double sum = lastEntries.Sum(x => x.Value.AdjustedClose);
        return sum / period;
    }
}