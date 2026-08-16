using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.Models;

namespace Yosoku.AlphaVantage;

public class AlphaVantageClient(HttpClient httpClient, IDistributedCache cache)
{
    private DateTimeOffset _lastCalled = DateTimeOffset.MinValue;

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

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
        var url = $"query?function={functionName}&symbol={symbol.ToUpper()}&outputsize=full";

        var response = await cache.GetStringAsync(url, token);
        if (response == null)
        {
            await Wait();
            response = await httpClient.GetStringAsync(url, token);
            await cache.SetStringAsync(url, response, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = new DateTimeOffset(2026, 8, 17, 18, 0, 0, 0, TimeSpan.Zero)
            }, token);
        }

        return JsonSerializer.Deserialize<T>(response, _jsonOptions)
            ?? throw new Exception($"Failed to deserialize cached response from {url}. Result was null.");
    }

    private async Task Wait(int rpm = 74)
    {
        var interval = (60.0 / rpm) * 1000;
        var diff = DateTimeOffset.Now - _lastCalled;
        if (diff.TotalMilliseconds < interval)
        {
            // wait
            var delay = interval - diff.TotalMilliseconds;
            Console.WriteLine($"Delaying {delay} ms");
            await Task.Delay((int)Math.Ceiling(delay));

        }
        _lastCalled = DateTimeOffset.Now;
    }
}