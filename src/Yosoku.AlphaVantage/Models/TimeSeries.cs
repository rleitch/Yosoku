using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class TimeSeries
{
    [JsonPropertyName("1. open")]
    public double Open { get; set; }

    [JsonPropertyName("2. high")]
    public double High { get; set; }

    [JsonPropertyName("3. low")]
    public double Low { get; set; }

    [JsonPropertyName("4. close")]
    public double Close { get; set; }

    [JsonPropertyName("5. adjusted close")]
    public double AdjustedClose { get; set; }

    [JsonPropertyName("6. volume")]
    public double Volume { get; set; }
}