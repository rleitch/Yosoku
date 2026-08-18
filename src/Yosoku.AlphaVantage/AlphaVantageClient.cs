using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Yosoku.AlphaVantage.Models;
using Yosoku.Core.Extensions;

namespace Yosoku.AlphaVantage;

public class AlphaVantageClient(
    HttpClient httpClient,
    IDistributedCache cache,
    ILogger<AlphaVantageClient> logger,
    JsonSerializerOptions jsonOptions) 
    : IAlphaVantageClient
{
    private readonly SemaphoreSlim _throttleSemaphore = new(1, 1);

    private DateTimeOffset _lastCalled = DateTimeOffset.MinValue;

    public async Task<TimeSeriesResponse> TimeSeriesDailyAsync(string symbol, CancellationToken token = default)
    {
        var data = await ThrottleAndGetFromJsonAsync<TimeSeriesResponse?>("TIME_SERIES_DAILY_ADJUSTED", symbol, token);
        if (data?.DailyTimeSeries == null)
        {
            throw new Exception($"Failed to get daily time series for symbol {symbol}");
        }
        return data;
    }

    public async Task<TimeSeriesResponse> TimeSeriesWeeklyAsync(string symbol, CancellationToken token = default)
    {
        var data = await ThrottleAndGetFromJsonAsync<TimeSeriesResponse?>("TIME_SERIES_WEEKLY_ADJUSTED", symbol, token);
        if (data?.WeeklyTimeSeries == null)
        {
            throw new Exception($"Failed to get weekly time series for symbol {symbol}");
        }
        return data;
    }
    public async Task<TimeSeriesResponse> TimeSeriesMonthlyAsync(string symbol, CancellationToken token = default)
    {
        var data = await ThrottleAndGetFromJsonAsync<TimeSeriesResponse?>("TIME_SERIES_MONTHLY_ADJUSTED", symbol, token);
        if (data?.MonthlyTimeSeries == null)
        {
            throw new Exception($"Failed to get monthly time series for symbol {symbol}");
        }
        return data;
    }

    public async Task<CompanyStatements<IncomeStatement>> GetIncomeStatements(string symbol, CancellationToken token = default)
    {
        return await ThrottleAndGetFromJsonAsync<CompanyStatements<IncomeStatement>>("INCOME_STATEMENT", symbol, token);
    }

    public async Task<CompanyStatements<BalanceSheet>> GetBalanceSheets(string symbol, CancellationToken token = default)
    {
        return await ThrottleAndGetFromJsonAsync<CompanyStatements<BalanceSheet>>("BALANCE_SHEET", symbol, token);
    }

    public async Task<CompanyStatements<CashFlow>> GetCashFlows(string symbol, CancellationToken token = default)
    {
        return await ThrottleAndGetFromJsonAsync<CompanyStatements<CashFlow>>("CASH_FLOW", symbol, token);
    }

    public async Task<EtfProfile> GetEtfProfile(string symbol, CancellationToken token = default)
    {
        return await ThrottleAndGetFromJsonAsync<EtfProfile>("ETF_PROFILE", symbol, token);
    }

    private async Task<T> ThrottleAndGetFromJsonAsync<T>(string functionName, string symbol, CancellationToken token = default)
    {
        var cacheKey = $"v1:{functionName}:{symbol.ToUpper()}";
        var url = $"query?function={functionName}&symbol={symbol.ToUpper()}&outputsize=full";
        //var url = $"query?function={functionName}&symbol={symbol.ToUpper()}";

        var response = await cache.GetStringAsync(cacheKey, token);
        if (response == null)
        {
            await Wait();
            response = await httpClient.GetStringAsync(url, token);
            await cache.SetStringAsync(cacheKey, response, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.ToNextSixPm()
            }, token);
        }

        return JsonSerializer.Deserialize<T>(response, jsonOptions)
            ?? throw new Exception($"Failed to deserialize cached response from {cacheKey}. Result was null.");
    }

    private async Task Wait(float rpm = 74.9F)
    {
        await _throttleSemaphore.WaitAsync();
        try
        {
            var interval = (60 / rpm) * 1000;
            var diff = DateTimeOffset.Now - _lastCalled;

            if (diff.TotalMilliseconds < interval)
            {
                var delay = interval - diff.TotalMilliseconds;
                logger.LogInformation($"Delaying {delay} ms to respect API rate limit of {rpm} requests per minute.");
                await Task.Delay((int)Math.Ceiling(delay));
            }

            _lastCalled = DateTimeOffset.Now;
        }
        finally
        {
            _throttleSemaphore.Release();
        }
    }
}