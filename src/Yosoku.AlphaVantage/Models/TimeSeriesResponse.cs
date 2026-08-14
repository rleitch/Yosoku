using System.Runtime.Serialization;

namespace Yosoku.AlphaVantage.Models;

[DataContract]
public class TimeSeriesResponse
{
    [DataMember(Name = "Meta Data")]
    public required MetaData MetaData { get; set; }

    [DataMember(Name = "Time Series (Daily)")]
    public Dictionary<DateTime, TimeSeries>? DailyTimeSeries { get; set; }

    [DataMember(Name = "Weekly Adjusted Time Series")]
    public Dictionary<DateTime, TimeSeries>? WeeklyTimeSeries { get; set; }

    [DataMember(Name = "Monthly Adjusted Time Series")]
    public Dictionary<DateTime, TimeSeries>? MonthlyTimeSeries { get; set; }
}