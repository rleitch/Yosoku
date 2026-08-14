using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Yosoku.AlphaVantage.DelegatingHandlers;

namespace Yosoku.AlphaVantage.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAlphaVantageClient(
        this IServiceCollection services,
        string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException("API key cannot be null or empty.", nameof(apiKey));
        }

        services.TryAddSingleton(sp => new ApiKeyHandler(apiKey));

        services.AddHttpClient<AlphaVantageClient>(client =>
        {
            client.BaseAddress = new Uri("https://www.alphavantage.co/");
        }).AddHttpMessageHandler<ApiKeyHandler>();

        return services;
    }
}