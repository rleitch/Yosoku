using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Yosoku.Data.Extensions;

public static class HostApplicationBuilderExtensions
{
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