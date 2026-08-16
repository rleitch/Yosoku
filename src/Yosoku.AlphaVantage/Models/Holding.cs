using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class Holding
{
    [JsonPropertyName("symbol")]
    public required string Symbol { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("weight")]
    public required string Weight { get; set; }
}