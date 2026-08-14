using Microsoft.Extensions.Options;
using Yosoku.AlphaVantage;
using Yosoku.Worker.Configuration;

namespace Yosoku.Worker;

public class Worker(ILogger<Worker> logger, AlphaVantageClient alphaVantageClient) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                var chingy = await alphaVantageClient.ImportDailyAsync("MSFT", stoppingToken);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}