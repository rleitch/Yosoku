using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.Models;

public class CashFlow
{
    [JsonPropertyName("capitalExpenditures")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CapitalExpenditures { get; set; }

    [JsonPropertyName("cashflowFromFinancing")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CashflowFromFinancing { get; set; }

    [JsonPropertyName("cashflowFromInvestment")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CashflowFromInvestment { get; set; }

    [JsonPropertyName("changeInCashAndCashEquivalents")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ChangeInCashAndCashEquivalents { get; set; }

    [JsonPropertyName("changeInExchangeRate")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ChangeInExchangeRate { get; set; }

    [JsonPropertyName("changeInInventory")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ChangeInInventory { get; set; }

    [JsonPropertyName("changeInOperatingAssets")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ChangeInOperatingAssets { get; set; }

    [JsonPropertyName("changeInOperatingLiabilities")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ChangeInOperatingLiabilities { get; set; }

    [JsonPropertyName("changeInReceivables")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ChangeInReceivables { get; set; }

    [JsonPropertyName("depreciationDepletionAndAmortization")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? DepreciationDepletionAndAmortization { get; set; }

    [JsonPropertyName("dividendPayout")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? DividendPayout { get; set; }

    [JsonPropertyName("dividendPayoutCommonStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? DividendPayoutCommonStock { get; set; }

    [JsonPropertyName("dividendPayoutPreferredStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? DividendPayoutPreferredStock { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("netIncome")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? NetIncome { get; set; }

    [JsonPropertyName("operatingCashflow")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? OperatingCashflow { get; set; }

    [JsonPropertyName("paymentsForOperatingActivities")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? PaymentsForOperatingActivities { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfCommonStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? PaymentsForRepurchaseOfCommonStock { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfEquity")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? PaymentsForRepurchaseOfEquity { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfPreferredStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? PaymentsForRepurchaseOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfCommonStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ProceedsFromIssuanceOfCommonStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfPreferredStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ProceedsFromIssuanceOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromOperatingActivities")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ProceedsFromOperatingActivities { get; set; }

    [JsonPropertyName("proceedsFromRepaymentsOfShortTermDebt")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ProceedsFromRepaymentsOfShortTermDebt { get; set; }

    [JsonPropertyName("proceedsFromRepurchaseOfEquity")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ProceedsFromRepurchaseOfEquity { get; set; }

    [JsonPropertyName("proceedsFromSaleOfTreasuryStock")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ProceedsFromSaleOfTreasuryStock { get; set; }

    [JsonPropertyName("profitLoss")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ProfitLoss { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public string? ReportedCurrency { get; set; }

    [JsonPropertyName("stockBasedCompensation")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? StockBasedCompensation { get; set; }
}