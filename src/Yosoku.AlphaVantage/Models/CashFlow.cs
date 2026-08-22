using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class CashFlow
{
    [JsonPropertyName("capitalExpenditures")]
    public double CapitalExpenditures { get; set; }

    [JsonPropertyName("cashflowFromFinancing")]
    public double? CashflowFromFinancing { get; set; }

    [JsonPropertyName("cashflowFromInvestment")]
    public double? CashflowFromInvestment { get; set; }

    [JsonPropertyName("changeInCashAndCashEquivalents")]
    public double? ChangeInCashAndCashEquivalents { get; set; }

    [JsonPropertyName("changeInExchangeRate")]
    public double? ChangeInExchangeRate { get; set; }

    [JsonPropertyName("changeInInventory")]
    public double? ChangeInInventory { get; set; }

    [JsonPropertyName("changeInOperatingAssets")]
    public double? ChangeInOperatingAssets { get; set; }

    [JsonPropertyName("changeInOperatingLiabilities")]
    public double? ChangeInOperatingLiabilities { get; set; }

    [JsonPropertyName("changeInReceivables")]
    public double? ChangeInReceivables { get; set; }

    [JsonPropertyName("depreciationDepletionAndAmortization")]
    public double? DepreciationDepletionAndAmortization { get; set; }

    [JsonPropertyName("dividendPayout")]
    public double? DividendPayout { get; set; }

    [JsonPropertyName("dividendPayoutCommonStock")]
    public double? DividendPayoutCommonStock { get; set; }

    [JsonPropertyName("dividendPayoutPreferredStock")]
    public double? DividendPayoutPreferredStock { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("netIncome")]
    public double? NetIncome { get; set; }

    [JsonPropertyName("operatingCashflow")]
    public double? OperatingCashflow { get; set; }

    [JsonPropertyName("paymentsForOperatingActivities")]
    public double? PaymentsForOperatingActivities { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfCommonStock")]
    public double? PaymentsForRepurchaseOfCommonStock { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfEquity")]
    public double? PaymentsForRepurchaseOfEquity { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfPreferredStock")]
    public double? PaymentsForRepurchaseOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfCommonStock")]
    public double? ProceedsFromIssuanceOfCommonStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
    public double? ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfPreferredStock")]
    public double? ProceedsFromIssuanceOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromOperatingActivities")]
    public double? ProceedsFromOperatingActivities { get; set; }

    [JsonPropertyName("proceedsFromRepaymentsOfShortTermDebt")]
    public double? ProceedsFromRepaymentsOfShortTermDebt { get; set; }

    [JsonPropertyName("proceedsFromRepurchaseOfEquity")]
    public double? ProceedsFromRepurchaseOfEquity { get; set; }

    [JsonPropertyName("proceedsFromSaleOfTreasuryStock")]
    public double? ProceedsFromSaleOfTreasuryStock { get; set; }

    [JsonPropertyName("profitLoss")]
    public double? ProfitLoss { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public string? ReportedCurrency { get; set; }

    [JsonPropertyName("stockBasedCompensation")]
    public double? StockBasedCompensation { get; set; }
}