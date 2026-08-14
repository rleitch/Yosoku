using Yosoku.AlphaVantage.Extensions;
using Yosoku.Worker;
using Yosoku.Worker.Configuration;

var builder = Host.CreateApplicationBuilder(args);
var optionsConfigurationSection = builder.Configuration.GetSection("Settings");
var options = new Settings();
optionsConfigurationSection.Bind(options);
builder.Services.Configure<Settings>(optionsConfigurationSection);
builder.Services.AddHostedService<Worker>();
builder.Services.AddAlphaVantageClient(options.ApiKey);
var host = builder.Build();
host.Run();