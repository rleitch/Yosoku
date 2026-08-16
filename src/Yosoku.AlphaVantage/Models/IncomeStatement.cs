using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.Models;

public class IncomeStatement
{
    // Core Income Metrics
    [JsonPropertyName("comprehensiveIncomeNetOfTax")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ComprehensiveIncomeNetOfTax { get; set; }

    [JsonPropertyName("costofGoodsAndServicesSold")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CostOfGoodsAndServicesSold { get; set; }

    [JsonPropertyName("costOfRevenue")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? CostOfRevenue { get; set; }

    [JsonPropertyName("depreciation")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? Depreciation { get; set; }

    [JsonPropertyName("depreciationAndAmortization")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? DepreciationAndAmortization { get; set; }

    [JsonPropertyName("ebit")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? Ebit { get; set; }

    [JsonPropertyName("ebitda")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? Ebitda { get; set; }

    // Date field, no converter needed.
    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("grossProfit")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? GrossProfit { get; set; }

    [JsonPropertyName("incomeBeforeTax")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? IncomeBeforeTax { get; set; }

    [JsonPropertyName("incomeTaxExpense")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? IncomeTaxExpense { get; set; }

    [JsonPropertyName("interestAndDebtExpense")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? InterestAndDebtExpense { get; set; }

    [JsonPropertyName("interestExpense")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? InterestExpense { get; set; }

    [JsonPropertyName("interestIncome")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? InterestIncome { get; set; }

    [JsonPropertyName("investmentIncomeNet")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? InvestmentIncomeNet { get; set; }

    [JsonPropertyName("netIncome")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? NetIncome { get; set; }

    [JsonPropertyName("netIncomeFromContinuingOperations")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? NetIncomeFromContinuingOperations { get; set; }

    [JsonPropertyName("netInterestIncome")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? NetInterestIncome { get; set; }

    [JsonPropertyName("nonInterestIncome")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? NonInterestIncome { get; set; }

    [JsonPropertyName("operatingExpenses")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? OperatingExpenses { get; set; }

    [JsonPropertyName("operatingIncome")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? OperatingIncome { get; set; }

    [JsonPropertyName("otherNonOperatingIncome")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? OtherNonOperatingIncome { get; set; }

    // Currency string, no converter needed.
    [JsonPropertyName("reportedCurrency")]
    public string ReportedCurrency { get; set; }

    [JsonPropertyName("researchAndDevelopment")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? ResearchAndDevelopment { get; set; }

    [JsonPropertyName("sellingGeneralAndAdministrative")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? SellingGeneralAndAdministrative { get; set; }

    [JsonPropertyName("totalRevenue")]
    [JsonConverter(typeof(NoneSafeDoubleConverter))]
    public double? TotalRevenue { get; set; }
}