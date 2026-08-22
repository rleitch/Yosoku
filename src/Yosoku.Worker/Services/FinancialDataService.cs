using System.Collections.Concurrent;
using Yosoku.AlphaVantage;
using Yosoku.Worker.Interfaces;
using Yosoku.Worker.Models;

namespace Yosoku.Worker.Services;

public class FinancialDataService(
    IAlphaVantageClient alphaVantageClient,
    ILogger<FinancialDataService> logger)
    : IFinancialDataService
{
    public async Task<FinancialData[]> GetFinancialDataAsync(string[] tickers, CancellationToken cancellationToken)
    {
        var results = new ConcurrentBag<FinancialData>();
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = 4,
            CancellationToken = cancellationToken
        };

        await Parallel.ForEachAsync(tickers, options, async (ticker, token) =>
        {
            var data = await GetFinancialDataAsync(ticker, token);
            if (data != null)
            {
                results.Add(data);
            }
        });

        return [.. results];
    }

    public async Task<FinancialData?> GetFinancialDataAsync(string ticker, CancellationToken cancellationToken)
    {
        try
        {
            var overviewTask = alphaVantageClient.GetCompanyOverview(ticker, cancellationToken);
            var dailyTask = alphaVantageClient.TimeSeriesDailyAsync(ticker, cancellationToken);
            var monthlyTask = alphaVantageClient.TimeSeriesMonthlyAsync(ticker, cancellationToken);
            var incomeStatementTask = alphaVantageClient.GetIncomeStatements(ticker, cancellationToken);
            var balanceSheetTask = alphaVantageClient.GetBalanceSheets(ticker, cancellationToken);
            var cashFlowTask = alphaVantageClient.GetCashFlows(ticker, cancellationToken);

            await Task.WhenAll(incomeStatementTask, balanceSheetTask, cashFlowTask, dailyTask, monthlyTask, overviewTask);

            var sortedIncomeStatements = incomeStatementTask.Result.QuarterlyReports
                .OrderBy(i => i.FiscalDateEnding).ToArray();

            var sortedBalanceSheets = balanceSheetTask.Result.QuarterlyReports
                .OrderBy(i => i.FiscalDateEnding).ToArray();

            var sortedCashFlows = cashFlowTask.Result.QuarterlyReports
                .OrderBy(i => i.FiscalDateEnding).ToArray();

            return new FinancialData
            {
                IncomeStatements = sortedIncomeStatements,
                CurrentIncomeStatement = sortedIncomeStatements[^1],
                BalanceSheets = sortedBalanceSheets,
                CurrentBalanceSheet = sortedBalanceSheets[^1],
                CashFlows = sortedCashFlows,
                CurrentCashFlow = sortedCashFlows[^1]
            };
        }
        catch (Exception e)
        {
            logger.LogError(e, $"Problem getting financial data for {ticker}");
            return null;
        }
    }
}