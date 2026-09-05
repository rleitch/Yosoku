using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class CashFlow
{
    [JsonPropertyName("capitalExpenditures")]
    public decimal? CapitalExpenditures { get; set; }

    [JsonPropertyName("cashflowFromFinancing")]
    public decimal? CashflowFromFinancing { get; set; }

    [JsonPropertyName("cashflowFromInvestment")]
    public decimal? CashflowFromInvestment { get; set; }

    [JsonPropertyName("changeInCashAndCashEquivalents")]
    public decimal? ChangeInCashAndCashEquivalents { get; set; }

    [JsonPropertyName("changeInExchangeRate")]
    public decimal? ChangeInExchangeRate { get; set; }

    [JsonPropertyName("changeInInventory")]
    public decimal? ChangeInInventory { get; set; }

    [JsonPropertyName("changeInOperatingAssets")]
    public decimal? ChangeInOperatingAssets { get; set; }

    [JsonPropertyName("changeInOperatingLiabilities")]
    public decimal? ChangeInOperatingLiabilities { get; set; }

    [JsonPropertyName("changeInReceivables")]
    public decimal? ChangeInReceivables { get; set; }

    [JsonPropertyName("depreciationDepletionAndAmortization")]
    public decimal? DepreciationDepletionAndAmortization { get; set; }

    [JsonPropertyName("dividendPayout")]
    public decimal? DividendPayout { get; set; }

    [JsonPropertyName("dividendPayoutCommonStock")]
    public decimal? DividendPayoutCommonStock { get; set; }

    [JsonPropertyName("dividendPayoutPreferredStock")]
    public decimal? DividendPayoutPreferredStock { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("netIncome")]
    public decimal? NetIncome { get; set; }

    [JsonPropertyName("operatingCashflow")]
    public decimal? OperatingCashflow { get; set; }

    [JsonPropertyName("paymentsForOperatingActivities")]
    public decimal? PaymentsForOperatingActivities { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfCommonStock")]
    public decimal? PaymentsForRepurchaseOfCommonStock { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfEquity")]
    public decimal? PaymentsForRepurchaseOfEquity { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfPreferredStock")]
    public decimal? PaymentsForRepurchaseOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfCommonStock")]
    public decimal? ProceedsFromIssuanceOfCommonStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
    public decimal? ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfPreferredStock")]
    public decimal? ProceedsFromIssuanceOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromOperatingActivities")]
    public decimal? ProceedsFromOperatingActivities { get; set; }

    [JsonPropertyName("proceedsFromRepaymentsOfShortTermDebt")]
    public decimal? ProceedsFromRepaymentsOfShortTermDebt { get; set; }

    [JsonPropertyName("proceedsFromRepurchaseOfEquity")]
    public decimal? ProceedsFromRepurchaseOfEquity { get; set; }

    [JsonPropertyName("proceedsFromSaleOfTreasuryStock")]
    public decimal? ProceedsFromSaleOfTreasuryStock { get; set; }

    [JsonPropertyName("profitLoss")]
    public decimal? ProfitLoss { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public string? ReportedCurrency { get; set; }

    [JsonPropertyName("stockBasedCompensation")]
    public decimal? StockBasedCompensation { get; set; }
}