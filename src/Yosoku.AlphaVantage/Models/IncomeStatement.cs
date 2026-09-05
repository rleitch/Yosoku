using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models;

public class IncomeStatement
{
    // Core Income Metrics
    [JsonPropertyName("comprehensiveIncomeNetOfTax")]
    public decimal? ComprehensiveIncomeNetOfTax { get; set; }

    [JsonPropertyName("costofGoodsAndServicesSold")]
    public decimal? CostOfGoodsAndServicesSold { get; set; }

    [JsonPropertyName("costOfRevenue")]
    public decimal? CostOfRevenue { get; set; }

    [JsonPropertyName("depreciation")]
    public decimal? Depreciation { get; set; }

    [JsonPropertyName("depreciationAndAmortization")]
    public decimal? DepreciationAndAmortization { get; set; }

    [JsonPropertyName("ebit")]
    public decimal? Ebit { get; set; }

    [JsonPropertyName("ebitda")]
    public decimal? Ebitda { get; set; }

    // Date field, no converter needed.
    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("grossProfit")]
    public decimal? GrossProfit { get; set; }

    [JsonPropertyName("incomeBeforeTax")]
    public decimal? IncomeBeforeTax { get; set; }

    [JsonPropertyName("incomeTaxExpense")]
    public decimal? IncomeTaxExpense { get; set; }

    [JsonPropertyName("interestAndDebtExpense")]
    public decimal? InterestAndDebtExpense { get; set; }

    [JsonPropertyName("interestExpense")]
    public decimal? InterestExpense { get; set; }

    [JsonPropertyName("interestIncome")]
    public decimal? InterestIncome { get; set; }

    [JsonPropertyName("investmentIncomeNet")]
    public decimal? InvestmentIncomeNet { get; set; }

    [JsonPropertyName("netIncome")]
    public decimal? NetIncome { get; set; }

    [JsonPropertyName("netIncomeFromContinuingOperations")]
    public decimal? NetIncomeFromContinuingOperations { get; set; }

    [JsonPropertyName("netInterestIncome")]
    public decimal? NetInterestIncome { get; set; }

    [JsonPropertyName("nonInterestIncome")]
    public decimal? NonInterestIncome { get; set; }

    [JsonPropertyName("operatingExpenses")]
    public decimal? OperatingExpenses { get; set; }

    [JsonPropertyName("operatingIncome")]
    public decimal? OperatingIncome { get; set; }

    [JsonPropertyName("otherNonOperatingIncome")]
    public decimal? OtherNonOperatingIncome { get; set; }

    // Currency string, no converter needed.
    [JsonPropertyName("reportedCurrency")]
    public required string ReportedCurrency { get; set; }

    [JsonPropertyName("researchAndDevelopment")]
    public decimal? ResearchAndDevelopment { get; set; }

    [JsonPropertyName("sellingGeneralAndAdministrative")]
    public decimal? SellingGeneralAndAdministrative { get; set; }

    [JsonPropertyName("totalRevenue")]
    public decimal? TotalRevenue { get; set; }
}