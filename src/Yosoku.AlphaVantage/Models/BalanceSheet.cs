using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class BalanceSheet
{
    [JsonPropertyName("accumulatedDepreciationAmortizationPPE")]
    public decimal? AccumulatedDepreciationAmortizationPPE { get; set; }

    [JsonPropertyName("capitalLeaseObligations")]
    public decimal? CapitalLeaseObligations { get; set; }

    [JsonPropertyName("cashAndCashEquivalentsAtCarryingValue")]
    public decimal? CashAndCashEquivalentsAtCarryingValue { get; set; }

    [JsonPropertyName("cashAndShortTermInvestments")]
    public decimal? CashAndShortTermInvestments { get; set; }

    [JsonPropertyName("commonStock")]
    public decimal? CommonStock { get; set; }

    [JsonPropertyName("commonStockSharesOutstanding")]
    public decimal? CommonStockSharesOutstanding { get; set; }

    [JsonPropertyName("currentAccountsPayable")]
    public decimal? CurrentAccountsPayable { get; set; }

    [JsonPropertyName("currentDebt")]
    public decimal? CurrentDebt { get; set; }

    [JsonPropertyName("currentLongTermDebt")]
    public decimal? CurrentLongTermDebt { get; set; }

    [JsonPropertyName("currentNetReceivables")]
    public decimal? CurrentNetReceivables { get; set; }

    [JsonPropertyName("deferredRevenue")]
    public decimal? DeferredRevenue { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("goodwill")]
    public decimal? Goodwill { get; set; }

    [JsonPropertyName("intangibleAssets")]
    public decimal? IntangibleAssets { get; set; }

    [JsonPropertyName("intangibleAssetsExcludingGoodwill")]
    public decimal? IntangibleAssetsExcludingGoodwill { get; set; }

    [JsonPropertyName("inventory")]
    public decimal? Inventory { get; set; }

    [JsonPropertyName("investments")]
    public decimal? Investments { get; set; }

    [JsonPropertyName("longTermDebt")]
    public decimal? LongTermDebt { get; set; }

    [JsonPropertyName("longTermDebtNoncurrent")]
    public decimal? LongTermDebtNoncurrent { get; set; }

    [JsonPropertyName("longTermInvestments")]
    public decimal? LongTermInvestments { get; set; }

    [JsonPropertyName("otherCurrentAssets")]
    public decimal? OtherCurrentAssets { get; set; }

    [JsonPropertyName("otherCurrentLiabilities")]
    public decimal? OtherCurrentLiabilities { get; set; }

    [JsonPropertyName("otherNonCurrentAssets")]
    public decimal? OtherNonCurrentAssets { get; set; }

    [JsonPropertyName("otherNonCurrentLiabilities")]
    public decimal? OtherNonCurrentLiabilities { get; set; }

    [JsonPropertyName("propertyPlantEquipment")]
    public decimal? PropertyPlantEquipment { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public required string ReportedCurrency { get; set; }

    [JsonPropertyName("retainedEarnings")]
    public decimal? RetainedEarnings { get; set; }

    [JsonPropertyName("shortLongTermDebtTotal")]
    public decimal? ShortLongTermDebtTotal { get; set; }

    [JsonPropertyName("shortTermDebt")]
    public decimal? ShortTermDebt { get; set; }

    [JsonPropertyName("shortTermInvestments")]
    public decimal? ShortTermInvestments { get; set; }

    [JsonPropertyName("totalAssets")]
    public decimal? TotalAssets { get; set; }

    [JsonPropertyName("totalCurrentAssets")]
    public decimal? TotalCurrentAssets { get; set; }

    [JsonPropertyName("totalCurrentLiabilities")]
    public decimal? TotalCurrentLiabilities { get; set; }

    [JsonPropertyName("totalLiabilities")]
    public decimal? TotalLiabilities { get; set; }

    [JsonPropertyName("totalNonCurrentAssets")]
    public decimal? TotalNonCurrentAssets { get; set; }

    [JsonPropertyName("totalNonCurrentLiabilities")]
    public decimal? TotalNonCurrentLiabilities { get; set; }

    [JsonPropertyName("totalShareholderEquity")]
    public decimal? TotalShareholderEquity { get; set; }

    [JsonPropertyName("treasuryStock")]
    public decimal? TreasuryStock { get; set; }
}