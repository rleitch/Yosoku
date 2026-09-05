using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class Quote
{
    [JsonPropertyName("1. open")]
    public decimal Open { get; set; }

    [JsonPropertyName("2. high")]
    public decimal High { get; set; }

    [JsonPropertyName("3. low")]
    public decimal Low { get; set; }

    [JsonPropertyName("4. close")]
    public decimal Close { get; set; }

    [JsonPropertyName("5. adjusted close")]
    public decimal AdjustedClose { get; set; }

    [JsonPropertyName("6. volume")]
    public decimal Volume { get; set; }
}