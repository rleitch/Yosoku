using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.Models;

public class IncomeStatement
{
    // Core Income Metrics
    [JsonPropertyName("comprehensiveIncomeNetOfTax")]
    public float? ComprehensiveIncomeNetOfTax { get; set; }

    [JsonPropertyName("costofGoodsAndServicesSold")]
    public float? CostOfGoodsAndServicesSold { get; set; }

    [JsonPropertyName("costOfRevenue")]
    public float? CostOfRevenue { get; set; }

    [JsonPropertyName("depreciation")]
    public float? Depreciation { get; set; }

    [JsonPropertyName("depreciationAndAmortization")]
    public float? DepreciationAndAmortization { get; set; }

    [JsonPropertyName("ebit")]
    public float? Ebit { get; set; }

    [JsonPropertyName("ebitda")]
    public float? Ebitda { get; set; }

    // Date field, no converter needed.
    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("grossProfit")]
    public float? GrossProfit { get; set; }

    [JsonPropertyName("incomeBeforeTax")]
    public float? IncomeBeforeTax { get; set; }

    [JsonPropertyName("incomeTaxExpense")]
    public float? IncomeTaxExpense { get; set; }

    [JsonPropertyName("interestAndDebtExpense")]
    public float? InterestAndDebtExpense { get; set; }

    [JsonPropertyName("interestExpense")]
    public float? InterestExpense { get; set; }

    [JsonPropertyName("interestIncome")]
    public float? InterestIncome { get; set; }

    [JsonPropertyName("investmentIncomeNet")]
    public float? InvestmentIncomeNet { get; set; }

    [JsonPropertyName("netIncome")]
    public float? NetIncome { get; set; }

    [JsonPropertyName("netIncomeFromContinuingOperations")]
    public float? NetIncomeFromContinuingOperations { get; set; }

    [JsonPropertyName("netInterestIncome")]
    public float? NetInterestIncome { get; set; }

    [JsonPropertyName("nonInterestIncome")]
    public float? NonInterestIncome { get; set; }

    [JsonPropertyName("operatingExpenses")]
    public float? OperatingExpenses { get; set; }

    [JsonPropertyName("operatingIncome")]
    public float? OperatingIncome { get; set; }

    [JsonPropertyName("otherNonOperatingIncome")]
    public float? OtherNonOperatingIncome { get; set; }

    // Currency string, no converter needed.
    [JsonPropertyName("reportedCurrency")]
    public required string ReportedCurrency { get; set; }

    [JsonPropertyName("researchAndDevelopment")]
    public float? ResearchAndDevelopment { get; set; }

    [JsonPropertyName("sellingGeneralAndAdministrative")]
    public float? SellingGeneralAndAdministrative { get; set; }

    [JsonPropertyName("totalRevenue")]
    public float? TotalRevenue { get; set; }
}