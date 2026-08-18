using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class Quote
{
    [JsonPropertyName("1. open")]
    public float Open { get; set; }

    [JsonPropertyName("2. high")]
    public float High { get; set; }

    [JsonPropertyName("3. low")]
    public float Low { get; set; }

    [JsonPropertyName("4. close")]
    public float Close { get; set; }

    [JsonPropertyName("5. adjusted close")]
    public float AdjustedClose { get; set; }

    [JsonPropertyName("6. volume")]
    public float Volume { get; set; }
}