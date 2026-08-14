using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.Models;

public class CashFlow
{
    [JsonPropertyName("capitalExpenditures")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CapitalExpenditures { get; set; }

    [JsonPropertyName("cashflowFromFinancing")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CashflowFromFinancing { get; set; }

    [JsonPropertyName("cashflowFromInvestment")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CashflowFromInvestment { get; set; }

    [JsonPropertyName("changeInCashAndCashEquivalents")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ChangeInCashAndCashEquivalents { get; set; }

    [JsonPropertyName("changeInExchangeRate")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ChangeInExchangeRate { get; set; }

    [JsonPropertyName("changeInInventory")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ChangeInInventory { get; set; }

    [JsonPropertyName("changeInOperatingAssets")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ChangeInOperatingAssets { get; set; }

    [JsonPropertyName("changeInOperatingLiabilities")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ChangeInOperatingLiabilities { get; set; }

    [JsonPropertyName("changeInReceivables")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ChangeInReceivables { get; set; }

    [JsonPropertyName("depreciationDepletionAndAmortization")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? DepreciationDepletionAndAmortization { get; set; }

    [JsonPropertyName("dividendPayout")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? DividendPayout { get; set; }

    [JsonPropertyName("dividendPayoutCommonStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? DividendPayoutCommonStock { get; set; }

    [JsonPropertyName("dividendPayoutPreferredStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? DividendPayoutPreferredStock { get; set; }

    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("netIncome")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? NetIncome { get; set; }

    [JsonPropertyName("operatingCashflow")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? OperatingCashflow { get; set; }

    [JsonPropertyName("paymentsForOperatingActivities")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? PaymentsForOperatingActivities { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfCommonStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? PaymentsForRepurchaseOfCommonStock { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfEquity")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? PaymentsForRepurchaseOfEquity { get; set; }

    [JsonPropertyName("paymentsForRepurchaseOfPreferredStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? PaymentsForRepurchaseOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfCommonStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ProceedsFromIssuanceOfCommonStock { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

    [JsonPropertyName("proceedsFromIssuanceOfPreferredStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ProceedsFromIssuanceOfPreferredStock { get; set; }

    [JsonPropertyName("proceedsFromOperatingActivities")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ProceedsFromOperatingActivities { get; set; }

    [JsonPropertyName("proceedsFromRepaymentsOfShortTermDebt")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ProceedsFromRepaymentsOfShortTermDebt { get; set; }

    [JsonPropertyName("proceedsFromRepurchaseOfEquity")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ProceedsFromRepurchaseOfEquity { get; set; }

    [JsonPropertyName("proceedsFromSaleOfTreasuryStock")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ProceedsFromSaleOfTreasuryStock { get; set; }

    [JsonPropertyName("profitLoss")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ProfitLoss { get; set; }

    [JsonPropertyName("reportedCurrency")]
    public string? ReportedCurrency { get; set; }

    [JsonPropertyName("stockBasedCompensation")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? StockBasedCompensation { get; set; }
}