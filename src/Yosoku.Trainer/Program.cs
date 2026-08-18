using Yosoku.Data.Extensions;
using Yosoku.Trainer;

var builder = Host.CreateApplicationBuilder(args);
builder.AddSqlServer();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
