using Microsoft.EntityFrameworkCore;
using Yosoku.AlphaVantage;
using Yosoku.Data;
using Yosoku.Worker.Interfaces;

namespace Yosoku.Worker;

public class Worker(
    ILogger<Worker> logger,
    IAlphaVantageClient alphaVantageClient,
    //IDbContextFactory<YosokuContext> DbFactory,
    //IMultiFactorScorer multiFactorScorer,
    IFinancialDataService financialDataService)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            //using var context = await DbFactory.CreateDbContextAsync(stoppingToken);

            var etfProfile = await alphaVantageClient.GetEtfProfile("IWR", stoppingToken);
            var etfProfile2 = await alphaVantageClient.GetEtfProfile("IYW", stoppingToken);

            var holdings = new List<string>();
            holdings.AddRange(etfProfile.Holdings.Select(h => h.Symbol));
            holdings.AddRange(etfProfile2.Holdings.Select(h => h.Symbol));

            holdings = [.. holdings.Distinct()];



            var chingy1 = await financialDataService.GetFinancialDataAsync("JLL", stoppingToken);

            var chingy2 = chingy1.IncomeStatements.OrderByDescending(s => s.Key).Skip(1).Take(4).ToList();

            var totalGrossProfit = chingy2.Sum(c => c.Value.GrossProfit.GetValueOrDefault(0));

            var totalRevenue = chingy2.Sum(c => c.Value.TotalRevenue.GetValueOrDefault(0));

            var totalCostOfRevenue = chingy2.Sum(c => c.Value.CostOfRevenue.GetValueOrDefault(0));


            var chingy = await financialDataService.GetFinancialDataAsync([.. holdings], stoppingToken);

            foreach (var item in chingy)
            {
                logger.LogInformation("{ticker} Gross Margin: {grossMargin}", item.Ticker, item.QuarterlySummaries.OrderByDescending(s => s.Key).First().Value.GrossMargin);
            }

            //var holdings = etfProfile.Holdings
            //    .OrderByDescending(h => h.Weight)
            //    .Select(h => h.Symbol)
            //    //.Take(25)
            //    .ToList();
            //var scores = await multiFactorScorer.GetTopStocksAsync(holdings, stoppingToken);

            //var chingy = string.Join(',', scores.Select(h => h.Symbol).Take(20));

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
}