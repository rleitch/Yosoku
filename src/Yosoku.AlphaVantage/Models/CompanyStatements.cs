using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class CompanyStatements<T>
{
    [JsonPropertyName("symbol")]
    public required string Symbol { get; set; }

    [JsonPropertyName("annualReports")]
    public required List<T> AnnualReports { get; set; }

    [JsonPropertyName("quarterlyReports")]
    public required List<T> QuarterlyReports { get; set; }
}