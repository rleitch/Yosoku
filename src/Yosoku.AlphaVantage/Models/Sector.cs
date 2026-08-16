using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class Sector
{
    [JsonPropertyName("sector")]
    public required string Name { get; set; }

    [JsonPropertyName("weight")]
    public required string Weight { get; set; }
}
