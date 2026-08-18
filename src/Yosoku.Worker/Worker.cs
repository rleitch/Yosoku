using Microsoft.EntityFrameworkCore;
using Yosoku.AlphaVantage;
using Yosoku.AlphaVantage.Services;
using Yosoku.Data;
using Yosoku.Data.Entities;

namespace Yosoku.Worker;

public class Worker(
    ILogger<Worker> logger,
    IAlphaVantageClient alphaVantageClient,
    IDbContextFactory<YosokuContext> DbFactory,
    IMarketDataService marketDataService)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            using var context = await DbFactory.CreateDbContextAsync(stoppingToken);

            var etfProfile = await alphaVantageClient.GetEtfProfile("VTI", stoppingToken);
            var count = 0;
            foreach (var holding in etfProfile.Holdings.OrderBy(h => h.Symbol))
            {
                try
                {
                    logger.LogInformation($"Processing {++count}/{etfProfile.Holdings.Count} - {holding.Symbol} - {holding.Description}");
                    var marketDataTask = marketDataService.GetMarketDataAsync(holding.Symbol, stoppingToken);
                    await context.Records
                        .Where(md => md.Ticker == holding.Symbol)
                        .LoadAsync(stoppingToken);
                    var marketData = await marketDataTask;
                    foreach (var month in marketData)
                    {
                        try
                        {
                            var existingRecord = context.Records.Local
                                .FirstOrDefault(r => r.Ticker == holding.Symbol && r.Date == month.Date);

                            if (existingRecord == null)
                            {
                                var newRecord = new Record(
                                    holding.Symbol,
                                    month.Date,
                                    month.FutureTotalReturn,
                                    0F,
                                    month.PeRatio,
                                    month.Sma50,
                                    month.Sma200);
                                context.Records.Add(newRecord);
                            }
                            else
                            {
                                existingRecord.Score = month.FutureTotalReturn;
                                existingRecord.PeRatio = month.PeRatio;
                                existingRecord.Sma50 = month.Sma50;
                                existingRecord.Sma200 = month.Sma200;
                            }
                        }
                        catch (Exception)
                        {
                            logger.LogError($"An error occurred while processing data for {holding.Symbol} on {month.Date}.");
                        }
                    }
                }
                catch (Exception e)
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
}