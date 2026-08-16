using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.Models;

public class TimeSeriesResponse
{
    [JsonPropertyName("Meta Data")]
    public required MetaData MetaData { get; set; }

    [JsonPropertyName("Time Series (Daily)")]
    [JsonConverter(typeof(DateOnlyDictionaryConverter))]
    public Dictionary<DateOnly, TimeSeries>? DailyTimeSeries { get; set; }

    [JsonPropertyName("Weekly Adjusted Time Series")]
    [JsonConverter(typeof(DateOnlyDictionaryConverter))]
    public Dictionary<DateOnly, TimeSeries>? WeeklyTimeSeries { get; set; }

    [JsonPropertyName("Monthly Adjusted Time Series")]
    [JsonConverter(typeof(DateOnlyDictionaryConverter))]
    public Dictionary<DateOnly, TimeSeries>? MonthlyTimeSeries { get; set; }
}