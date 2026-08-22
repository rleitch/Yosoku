using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class IncomeStatement
{
    // Core Income Metrics
    [JsonPropertyName("comprehensiveIncomeNetOfTax")]
    public double? ComprehensiveIncomeNetOfTax { get; set; }

    [JsonPropertyName("costofGoodsAndServicesSold")]
    public double? CostOfGoodsAndServicesSold { get; set; }

    [JsonPropertyName("costOfRevenue")]
    public double? CostOfRevenue { get; set; }

    [JsonPropertyName("depreciation")]
    public double? Depreciation { get; set; }

    [JsonPropertyName("depreciationAndAmortization")]
    public double? DepreciationAndAmortization { get; set; }

    [JsonPropertyName("ebit")]
    public double? Ebit { get; set; }

    [JsonPropertyName("ebitda")]
    public double? Ebitda { get; set; }

    // Date field, no converter needed.
    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("grossProfit")]
    public double? GrossProfit { get; set; }

    [JsonPropertyName("incomeBeforeTax")]
    public double? IncomeBeforeTax { get; set; }

    [JsonPropertyName("incomeTaxExpense")]
    public double? IncomeTaxExpense { get; set; }

    [JsonPropertyName("interestAndDebtExpense")]
    public double? InterestAndDebtExpense { get; set; }

    [JsonPropertyName("interestExpense")]
    public double? InterestExpense { get; set; }

    [JsonPropertyName("interestIncome")]
    public double? InterestIncome { get; set; }

    [JsonPropertyName("investmentIncomeNet")]
    public double? InvestmentIncomeNet { get; set; }

    [JsonPropertyName("netIncome")]
    public double? NetIncome { get; set; }

    [JsonPropertyName("netIncomeFromContinuingOperations")]
    public double? NetIncomeFromContinuingOperations { get; set; }

    [JsonPropertyName("netInterestIncome")]
    public double? NetInterestIncome { get; set; }

    [JsonPropertyName("nonInterestIncome")]
    public double? NonInterestIncome { get; set; }

    [JsonPropertyName("operatingExpenses")]
    public double? OperatingExpenses { get; set; }

    [JsonPropertyName("operatingIncome")]
    public double? OperatingIncome { get; set; }

    [JsonPropertyName("otherNonOperatingIncome")]
    public double? OtherNonOperatingIncome { get; set; }

    // Currency string, no converter needed.
    [JsonPropertyName("reportedCurrency")]
    public required string ReportedCurrency { get; set; }

    [JsonPropertyName("researchAndDevelopment")]
    public double? ResearchAndDevelopment { get; set; }

    [JsonPropertyName("sellingGeneralAndAdministrative")]
    public double? SellingGeneralAndAdministrative { get; set; }

    [JsonPropertyName("totalRevenue")]
    public double? TotalRevenue { get; set; }
}