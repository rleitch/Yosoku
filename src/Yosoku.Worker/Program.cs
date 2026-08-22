using System.Text.Json;
using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.Extensions;
using Yosoku.AlphaVantage.JsonConverterFactories;
using Yosoku.AlphaVantage.JsonConverters;
using Yosoku.Data.Extensions;
using Yosoku.Worker;
using Yosoku.Worker.Configuration;
using Yosoku.Worker.Extensions;
using Yosoku.Worker.Interfaces;
using Yosoku.Worker.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("CacheConnection");
        var settings = builder
            .AddSqlServer()
            .AddSettings<Settings>();
        builder.Services
            .AddHostedService<Worker>()
            .AddAlphaVantageClient(settings.ApiKey)
            .AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = connectionString;
                options.SchemaName = "dbo";
                options.TableName = "DistributedCache";
            })
            .AddSingleton<JsonConverterFactory, NoneSafeFloatConverterFactory>()
            .AddSingleton(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<NoneSafeFloatConverter>>();
                var options = new JsonSerializerOptions
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    Converters = { new NoneSafeFloatConverterFactory(logger) }
                };
                return options;
            })
            .AddSingleton<IFinancialDataService, FinancialDataService>();

        var host = builder.Build();
        host.Run();
    }
}