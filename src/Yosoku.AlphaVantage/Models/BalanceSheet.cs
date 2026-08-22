using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class BalanceSheet
{
    [JsonPropertyName("accumulatedDepreciationAmortizationPPE")]
    public double? AccumulatedDepreciationAmortizationPPE { get; set; }

    [JsonPropertyName("capitalLeaseObligations")]
    public double? CapitalLeaseObligations { get; set; }

    [JsonPropertyName("cashAndCashEquivalentsAtCarryingValue")]
    public double? CashAndCashEquivalentsAtCarryingValue { get; set; }

    [JsonPropertyName("cashAndShortTermInvestments")]
    public double? CashAndShortTermInvestments { get; set; }

    [JsonPropertyName("commonStock")]
    public double? CommonStock { get; set; }

    [JsonPropertyName("commonStockSharesOutstanding")]
    public double? CommonStockSharesOutstanding { get; set; }

    [JsonPropertyName("currentAccountsPayable")]
    public double? CurrentAccountsPayable { get; set; }

    [JsonPropertyName("currentDebt")]
    public double? CurrentDebt { get; set; }

    [JsonPropertyName("currentLongTermDebt")]
    public double? CurrentLongTermDebt { get; set; }

    [JsonPropertyName("currentNetReceivables")]
    public double? CurrentNetReceivables { get; set; }

    [JsonPropertyName("deferredRevenue")]
    public double? DeferredRevenue { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("goodwill")]
    public double? Goodwill { get; set; }

    [JsonPropertyName("intangibleAssets")]
    public double? IntangibleAssets { get; set; }

    [JsonPropertyName("intangibleAssetsExcludingGoodwill")]
    public double? IntangibleAssetsExcludingGoodwill { get; set; }

    [JsonPropertyName("inventory")]
    public double? Inventory { get; set; }

    [JsonPropertyName("investments")]
    public double? Investments { get; set; }

    [JsonPropertyName("longTermDebt")]
    public double? LongTermDebt { get; set; }

    [JsonPropertyName("longTermDebtNoncurrent")]
    public double? LongTermDebtNoncurrent { get; set; }

    [JsonPropertyName("longTermInvestments")]
    public double? LongTermInvestments { get; set; }

    [JsonPropertyName("otherCurrentAssets")]
    public double? OtherCurrentAssets { get; set; }

    [JsonPropertyName("otherCurrentLiabilities")]
    public double? OtherCurrentLiabilities { get; set; }

    [JsonPropertyName("otherNonCurrentAssets")]
    public double? OtherNonCurrentAssets { get; set; }

    [JsonPropertyName("otherNonCurrentLiabilities")]
    public double? OtherNonCurrentLiabilities { get; set; }

    [JsonPropertyName("propertyPlantEquipment")]
    public double? PropertyPlantEquipment { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public required string ReportedCurrency { get; set; }

    [JsonPropertyName("retainedEarnings")]
    public double? RetainedEarnings { get; set; }

    [JsonPropertyName("shortLongTermDebtTotal")]
    public double? ShortLongTermDebtTotal { get; set; }

    [JsonPropertyName("shortTermDebt")]
    public double? ShortTermDebt { get; set; }

    [JsonPropertyName("shortTermInvestments")]
    public double? ShortTermInvestments { get; set; }

    [JsonPropertyName("totalAssets")]
    public double? TotalAssets { get; set; }

    [JsonPropertyName("totalCurrentAssets")]
    public double? TotalCurrentAssets { get; set; }

    [JsonPropertyName("totalCurrentLiabilities")]
    public double? TotalCurrentLiabilities { get; set; }

    [JsonPropertyName("totalLiabilities")]
    public double? TotalLiabilities { get; set; }

    [JsonPropertyName("totalNonCurrentAssets")]
    public double? TotalNonCurrentAssets { get; set; }

    [JsonPropertyName("totalNonCurrentLiabilities")]
    public double? TotalNonCurrentLiabilities { get; set; }

    [JsonPropertyName("totalShareholderEquity")]
    public double? TotalShareholderEquity { get; set; }

    [JsonPropertyName("treasuryStock")]
    public double? TreasuryStock { get; set; }
}