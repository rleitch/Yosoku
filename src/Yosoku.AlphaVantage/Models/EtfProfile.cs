using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class EtfProfile
{
    [JsonPropertyName("net_assets")]
    public required string NetAssets { get; set; }

    [JsonPropertyName("net_expense_ratio")]
    public required string NetExpenseRatio { get; set; }

    [JsonPropertyName("portfolio_turnover")]
    public required string PortfolioTurnover { get; set; }

    [JsonPropertyName("dividend_yield")]
    public required string DividendYield { get; set; }

    [JsonPropertyName("inception_date")]
    public required string InceptionDate { get; set; }

    [JsonPropertyName("leveraged")]
    public required string Leveraged { get; set; }

    [JsonPropertyName("sectors")]
    public required List<Sector> Sectors { get; set; }

    [JsonPropertyName("holdings")]
    public required List<Holding> Holdings { get; set; }
}