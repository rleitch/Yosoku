using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class CashFlow
{
    [JsonPropertyName("capitalExpenditures")]
    public float? CapitalExpenditures { get; set; }

    [JsonPropertyName("cashflowFromFinancing")]
    public float? CashflowFromFinancing { get; set; }

    [JsonPropertyName("cashflowFromInvestment")]
    public float? CashflowFromInvestment { get; set; }

    [JsonPropertyName("changeInCashAndCashEquivalents")]
    public float? ChangeInCashAndCashEquivalents { get; set; }

    [JsonPropertyName("changeInExchangeRate")]
    public float? ChangeInExchangeRate { get; set; }

    [JsonPropertyName("changeInInventory")]
    public float? ChangeInInventory { get; set; }

    [JsonPropertyName("changeInOperatingAssets")]
    public float? ChangeInOperatingAssets { get; set; }

    [JsonPropertyName("changeInOperatingLiabilities")]
    public float? ChangeInOperatingLiabilities { get; set; }

    [JsonPropertyName("changeInReceivables")]
    public float? ChangeInReceivables { get; set; }

    [JsonPropertyName("depreciationDepletionAndAmortization")]
    public float? DepreciationDepletionAndAmortization { get; set; }

    [JsonPropertyName("dividendPayout")]
    public float? DividendPayout { get; set; }

    [JsonPropertyName("dividendPayoutCommonStock")]
    public float? DividendPayoutCommonStock { get; set; }

    [JsonPropertyName("dividendPayoutPreferredStock")]
    public float? DividendPayoutPreferredStock { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("netIncome")]
    public float? NetIncome { get; set; }

    [JsonPropertyName("operatingCashflow")]
    public float? OperatingCashflow { get; set; }

    [JsonPropertyName("paymentsForOperatingActivities")]
    public float? PaymentsForOperatingActivities { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfCommonStock")]
    public float? PaymentsForRepurchaseOfCommonStock { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfEquity")]
    public float? PaymentsForRepurchaseOfEquity { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfPreferredStock")]
    public float? PaymentsForRepurchaseOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfCommonStock")]
    public float? ProceedsFromIssuanceOfCommonStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
    public float? ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfPreferredStock")]
    public float? ProceedsFromIssuanceOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromOperatingActivities")]
    public float? ProceedsFromOperatingActivities { get; set; }

    [JsonPropertyName("proceedsFromRepaymentsOfShortTermDebt")]
    public float? ProceedsFromRepaymentsOfShortTermDebt { get; set; }

    [JsonPropertyName("proceedsFromRepurchaseOfEquity")]
    public float? ProceedsFromRepurchaseOfEquity { get; set; }

    [JsonPropertyName("proceedsFromSaleOfTreasuryStock")]
    public float? ProceedsFromSaleOfTreasuryStock { get; set; }

    [JsonPropertyName("profitLoss")]
    public float? ProfitLoss { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public string? ReportedCurrency { get; set; }

    [JsonPropertyName("stockBasedCompensation")]
    public float? StockBasedCompensation { get; set; }
}