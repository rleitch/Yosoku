using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Yosoku.Data;
using Yosoku.Trainer.Models;

namespace Yosoku.Trainer;

public class Worker(
    ILogger<Worker> logger,
    IDbContextFactory<YosokuContext> DbFactory)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            var mlContext = new MLContext(seed: 1);
            using var context = await DbFactory.CreateDbContextAsync(stoppingToken);

            // 1. Get all records sorted chronologically
            var allRecords = await context.Records
                .AsNoTracking()
                .OrderBy(r => r.Date)
                .ToListAsync(stoppingToken);

            if (allRecords.Any())
            {
                // Start at the first date in your dataset
                var currentStartDate = allRecords.First().Date;
                var finalDate = allRecords.Last().Date;

                // Loop until we reach the end of the dataset
                while (currentStartDate <= finalDate)
                {
                    var trainEnd = currentStartDate.AddMonths(5);
                    var testEnd = trainEnd.AddMonths(4);

                    // Filter data based on the calculated date windows
                    var trainData = allRecords
                        .Where(r => r.Date >= currentStartDate && r.Date < trainEnd)
                        .Select(r => new ModelInput
                        {
                            PeRatio = r.PeRatio,
                            Sma50 = r.Sma50,
                            Sma200 = r.Sma200,
                            Label = r.Score
                        }).ToList();

                    var testData = allRecords
                        .Where(r => r.Date >= trainEnd && r.Date < testEnd)
                        .Select(r => new ModelInput
                        {
                            PeRatio = r.PeRatio,
                            Sma50 = r.Sma50,
                            Sma200 = r.Sma200,
                            Label = r.Score
                        }).ToList();

                    // Only train if we have data in both windows
                    if (trainData.Any() && testData.Any())
                    {
                        var trainView = mlContext.Data.LoadFromEnumerable(trainData);
                        var testView = mlContext.Data.LoadFromEnumerable(testData);

                        var pipeline = mlContext.Transforms.Concatenate("Features", "PeRatio", "Sma50", "Sma200")
                            .Append(mlContext.Regression.Trainers.LightGbm());

                        var model = pipeline.Fit(trainView);
                        var predictions = model.Transform(testView);
                        var metrics = mlContext.Regression.Evaluate(predictions);

                        logger.LogInformation($"Window {currentStartDate:yyyy-MM}: R-Squared: {metrics.RSquared:F4}, RMSE: {metrics.RootMeanSquaredError:F4}");
                    }

                    // Move the start date forward by 1 month (or more if you want a bigger step)
                    currentStartDate = testEnd;
                }
            }

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while executing the trainer.");
        }
    }

}