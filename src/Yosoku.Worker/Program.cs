using Yosoku.AlphaVantage.Extensions;
using Yosoku.Worker;
using Yosoku.Worker.Configuration;
using Yosoku.Worker.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("CacheConnection");
        var settings = builder
            .AddSqlServer()
            .AddSettings<Settings>();
        builder.Services.AddHostedService<Worker>();
        builder.Services.AddAlphaVantageClient(settings.ApiKey)
            .AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = connectionString;
                options.SchemaName = "dbo";
                options.TableName = "DistributedCache";
            });
        var host = builder.Build();
        host.Run();
    }
}