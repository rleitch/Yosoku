using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.Models;

public class BalanceSheet
{
    [JsonPropertyName("accumulatedDepreciationAmortizationPPE")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? AccumulatedDepreciationAmortizationPPE { get; set; }

    [JsonPropertyName("capitalLeaseObligations")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CapitalLeaseObligations { get; set; }

    [JsonPropertyName("cashAndCashEquivalentsAtCarryingValue")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CashAndCashEquivalentsAtCarryingValue { get; set; }

    [JsonPropertyName("cashAndShortTermInvestments")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CashAndShortTermInvestments { get; set; }

    [JsonPropertyName("commonStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CommonStock { get; set; }

    [JsonPropertyName("commonStockSharesOutstanding")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CommonStockSharesOutstanding { get; set; }

    [JsonPropertyName("currentAccountsPayable")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CurrentAccountsPayable { get; set; }

    [JsonPropertyName("currentDebt")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CurrentDebt { get; set; }

    [JsonPropertyName("currentLongTermDebt")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CurrentLongTermDebt { get; set; }

    [JsonPropertyName("currentNetReceivables")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CurrentNetReceivables { get; set; }

    [JsonPropertyName("deferredRevenue")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? DeferredRevenue { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("goodwill")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? Goodwill { get; set; }

    [JsonPropertyName("intangibleAssets")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? IntangibleAssets { get; set; }

    [JsonPropertyName("intangibleAssetsExcludingGoodwill")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? IntangibleAssetsExcludingGoodwill { get; set; }

    [JsonPropertyName("inventory")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? Inventory { get; set; }

    [JsonPropertyName("investments")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? Investments { get; set; }

    [JsonPropertyName("longTermDebt")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? LongTermDebt { get; set; }

    [JsonPropertyName("longTermDebtNoncurrent")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? LongTermDebtNoncurrent { get; set; }

    [JsonPropertyName("longTermInvestments")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? LongTermInvestments { get; set; }

    [JsonPropertyName("otherCurrentAssets")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? OtherCurrentAssets { get; set; }

    [JsonPropertyName("otherCurrentLiabilities")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? OtherCurrentLiabilities { get; set; }

    [JsonPropertyName("otherNonCurrentAssets")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? OtherNonCurrentAssets { get; set; }

    [JsonPropertyName("otherNonCurrentLiabilities")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? OtherNonCurrentLiabilities { get; set; }

    [JsonPropertyName("propertyPlantEquipment")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? PropertyPlantEquipment { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public string ReportedCurrency { get; set; }

    [JsonPropertyName("retainedEarnings")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? RetainedEarnings { get; set; }

    [JsonPropertyName("shortLongTermDebtTotal")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ShortLongTermDebtTotal { get; set; }

    [JsonPropertyName("shortTermDebt")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ShortTermDebt { get; set; }

    [JsonPropertyName("shortTermInvestments")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ShortTermInvestments { get; set; }

    [JsonPropertyName("totalAssets")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TotalAssets { get; set; }

    [JsonPropertyName("totalCurrentAssets")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TotalCurrentAssets { get; set; }

    [JsonPropertyName("totalCurrentLiabilities")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TotalCurrentLiabilities { get; set; }

    [JsonPropertyName("totalLiabilities")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TotalLiabilities { get; set; }

    [JsonPropertyName("totalNonCurrentAssets")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TotalNonCurrentAssets { get; set; }

    [JsonPropertyName("totalNonCurrentLiabilities")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TotalNonCurrentLiabilities { get; set; }

    [JsonPropertyName("totalShareholderEquity")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TotalShareholderEquity { get; set; }

    [JsonPropertyName("treasuryStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TreasuryStock { get; set; }
}