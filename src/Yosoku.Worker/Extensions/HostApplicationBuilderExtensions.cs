using Microsoft.EntityFrameworkCore;
using Yosoku.Data;

namespace Yosoku.Worker.Extensions;

public static class HostApplicationBuilderExtensions
{
    public static T AddSettings<T>(this HostApplicationBuilder builder, string sectionName = "Settings")
        where T : class
    {
        var section = builder.Configuration.GetSection(sectionName);
        var settings = Activator.CreateInstance<T>();
        section.Bind(settings);
        builder.Services.Configure<T>(section);
        return settings;
    }

    public static HostApplicationBuilder AddSqlServer(this HostApplicationBuilder builder)
    {
        var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContextFactory<YosokuContext>(options =>
        {
            options.UseSqlServer(
                connectionString,
                sqlOptions => sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null)
            );
        });

        return builder;
    }
}