using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Yosoku.AlphaVantage.Models;

namespace Yosoku.AlphaVantage;

public class AlphaVantageClient(HttpClient httpClient)
{
    private DateTimeOffset _lastCalled = DateTimeOffset.MinValue;

    private static readonly DataContractJsonSerializer _dataContractJsonSerializer = new(typeof(TimeSeriesResponse), new DataContractJsonSerializerSettings()
    {
        UseSimpleDictionaryFormat = true,
        DateTimeFormat = new DateTimeFormat("yyyy-MM-dd")
    });

    public async Task<TimeSeriesResponse> ImportDailyAsync(string symbol, CancellationToken token = default)
    {
        var url = $"query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={symbol.ToUpper()}&outputsize=full";
        await Wait();
        var response = await httpClient.GetStringAsync(url, token);

        byte[] byteArray = Encoding.UTF8.GetBytes(response);
        using var ms = new MemoryStream(byteArray);
        TimeSeriesResponse alphaVantageResponse = (TimeSeriesResponse)_dataContractJsonSerializer.ReadObject(ms);
        return alphaVantageResponse;
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