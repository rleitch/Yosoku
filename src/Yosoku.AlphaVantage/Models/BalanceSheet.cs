using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class BalanceSheet
{
    [JsonPropertyName("accumulatedDepreciationAmortizationPPE")]
    public float? AccumulatedDepreciationAmortizationPPE { get; set; }

    [JsonPropertyName("capitalLeaseObligations")]
    public float? CapitalLeaseObligations { get; set; }

    [JsonPropertyName("cashAndCashEquivalentsAtCarryingValue")]
    public float? CashAndCashEquivalentsAtCarryingValue { get; set; }

    [JsonPropertyName("cashAndShortTermInvestments")]
    public float? CashAndShortTermInvestments { get; set; }

    [JsonPropertyName("commonStock")]
    public float? CommonStock { get; set; }

    [JsonPropertyName("commonStockSharesOutstanding")]
    public float? CommonStockSharesOutstanding { get; set; }

    [JsonPropertyName("currentAccountsPayable")]
    public float? CurrentAccountsPayable { get; set; }

    [JsonPropertyName("currentDebt")]
    public float? CurrentDebt { get; set; }

    [JsonPropertyName("currentLongTermDebt")]
    public float? CurrentLongTermDebt { get; set; }

    [JsonPropertyName("currentNetReceivables")]
    public float? CurrentNetReceivables { get; set; }

    [JsonPropertyName("deferredRevenue")]
    public float? DeferredRevenue { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("goodwill")]
    public float? Goodwill { get; set; }

    [JsonPropertyName("intangibleAssets")]
    public float? IntangibleAssets { get; set; }

    [JsonPropertyName("intangibleAssetsExcludingGoodwill")]
    public float? IntangibleAssetsExcludingGoodwill { get; set; }

    [JsonPropertyName("inventory")]
    public float? Inventory { get; set; }

    [JsonPropertyName("investments")]
    public float? Investments { get; set; }

    [JsonPropertyName("longTermDebt")]
    public float? LongTermDebt { get; set; }

    [JsonPropertyName("longTermDebtNoncurrent")]
    public float? LongTermDebtNoncurrent { get; set; }

    [JsonPropertyName("longTermInvestments")]
    public float? LongTermInvestments { get; set; }

    [JsonPropertyName("otherCurrentAssets")]
    public float? OtherCurrentAssets { get; set; }

    [JsonPropertyName("otherCurrentLiabilities")]
    public float? OtherCurrentLiabilities { get; set; }

    [JsonPropertyName("otherNonCurrentAssets")]
    public float? OtherNonCurrentAssets { get; set; }

    [JsonPropertyName("otherNonCurrentLiabilities")]
    public float? OtherNonCurrentLiabilities { get; set; }

    [JsonPropertyName("propertyPlantEquipment")]
    public float? PropertyPlantEquipment { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public required string ReportedCurrency { get; set; }

    [JsonPropertyName("retainedEarnings")]
    public float? RetainedEarnings { get; set; }

    [JsonPropertyName("shortLongTermDebtTotal")]
    public float? ShortLongTermDebtTotal { get; set; }

    [JsonPropertyName("shortTermDebt")]
    public float? ShortTermDebt { get; set; }

    [JsonPropertyName("shortTermInvestments")]
    public float? ShortTermInvestments { get; set; }

    [JsonPropertyName("totalAssets")]
    public float? TotalAssets { get; set; }

    [JsonPropertyName("totalCurrentAssets")]
    public float? TotalCurrentAssets { get; set; }

    [JsonPropertyName("totalCurrentLiabilities")]
    public float? TotalCurrentLiabilities { get; set; }

    [JsonPropertyName("totalLiabilities")]
    public float? TotalLiabilities { get; set; }

    [JsonPropertyName("totalNonCurrentAssets")]
    public float? TotalNonCurrentAssets { get; set; }

    [JsonPropertyName("totalNonCurrentLiabilities")]
    public float? TotalNonCurrentLiabilities { get; set; }

    [JsonPropertyName("totalShareholderEquity")]
    public float? TotalShareholderEquity { get; set; }

    [JsonPropertyName("treasuryStock")]
    public float? TreasuryStock { get; set; }
}