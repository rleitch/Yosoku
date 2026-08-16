using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.Models;

public class BalanceSheet
{
    [JsonPropertyName("accumulatedDepreciationAmortizationPPE")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? AccumulatedDepreciationAmortizationPPE { get; set; }

    [JsonPropertyName("capitalLeaseObligations")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CapitalLeaseObligations { get; set; }

    [JsonPropertyName("cashAndCashEquivalentsAtCarryingValue")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CashAndCashEquivalentsAtCarryingValue { get; set; }

    [JsonPropertyName("cashAndShortTermInvestments")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CashAndShortTermInvestments { get; set; }

    [JsonPropertyName("commonStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CommonStock { get; set; }

    [JsonPropertyName("commonStockSharesOutstanding")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CommonStockSharesOutstanding { get; set; }

    [JsonPropertyName("currentAccountsPayable")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CurrentAccountsPayable { get; set; }

    [JsonPropertyName("currentDebt")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CurrentDebt { get; set; }

    [JsonPropertyName("currentLongTermDebt")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CurrentLongTermDebt { get; set; }

    [JsonPropertyName("currentNetReceivables")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CurrentNetReceivables { get; set; }

    [JsonPropertyName("deferredRevenue")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? DeferredRevenue { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("goodwill")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? Goodwill { get; set; }

    [JsonPropertyName("intangibleAssets")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? IntangibleAssets { get; set; }

    [JsonPropertyName("intangibleAssetsExcludingGoodwill")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? IntangibleAssetsExcludingGoodwill { get; set; }

    [JsonPropertyName("inventory")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? Inventory { get; set; }

    [JsonPropertyName("investments")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? Investments { get; set; }

    [JsonPropertyName("longTermDebt")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? LongTermDebt { get; set; }

    [JsonPropertyName("longTermDebtNoncurrent")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? LongTermDebtNoncurrent { get; set; }

    [JsonPropertyName("longTermInvestments")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? LongTermInvestments { get; set; }

    [JsonPropertyName("otherCurrentAssets")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? OtherCurrentAssets { get; set; }

    [JsonPropertyName("otherCurrentLiabilities")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? OtherCurrentLiabilities { get; set; }

    [JsonPropertyName("otherNonCurrentAssets")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? OtherNonCurrentAssets { get; set; }

    [JsonPropertyName("otherNonCurrentLiabilities")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? OtherNonCurrentLiabilities { get; set; }

    [JsonPropertyName("propertyPlantEquipment")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? PropertyPlantEquipment { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public string ReportedCurrency { get; set; }

    [JsonPropertyName("retainedEarnings")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? RetainedEarnings { get; set; }

    [JsonPropertyName("shortLongTermDebtTotal")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ShortLongTermDebtTotal { get; set; }

    [JsonPropertyName("shortTermDebt")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ShortTermDebt { get; set; }

    [JsonPropertyName("shortTermInvestments")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ShortTermInvestments { get; set; }

    [JsonPropertyName("totalAssets")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TotalAssets { get; set; }

    [JsonPropertyName("totalCurrentAssets")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TotalCurrentAssets { get; set; }

    [JsonPropertyName("totalCurrentLiabilities")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TotalCurrentLiabilities { get; set; }

    [JsonPropertyName("totalLiabilities")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TotalLiabilities { get; set; }

    [JsonPropertyName("totalNonCurrentAssets")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TotalNonCurrentAssets { get; set; }

    [JsonPropertyName("totalNonCurrentLiabilities")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TotalNonCurrentLiabilities { get; set; }

    [JsonPropertyName("totalShareholderEquity")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TotalShareholderEquity { get; set; }

    [JsonPropertyName("treasuryStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TreasuryStock { get; set; }
}