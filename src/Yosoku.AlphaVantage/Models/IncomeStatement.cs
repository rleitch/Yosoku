using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.Models;

public class IncomeStatement
{
    // Core Income Metrics
    [JsonPropertyName("comprehensiveIncomeNetOfTax")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ComprehensiveIncomeNetOfTax { get; set; }

    [JsonPropertyName("costofGoodsAndServicesSold")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CostOfGoodsAndServicesSold { get; set; }

    [JsonPropertyName("costOfRevenue")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? CostOfRevenue { get; set; }

    [JsonPropertyName("depreciation")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? Depreciation { get; set; }

    [JsonPropertyName("depreciationAndAmortization")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? DepreciationAndAmortization { get; set; }

    [JsonPropertyName("ebit")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? Ebit { get; set; }

    [JsonPropertyName("ebitda")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? Ebitda { get; set; }

    // Date field, no converter needed.
    [JsonPropertyName("fiscalDateEnding")]
    public DateOnly FiscalDateEnding { get; set; }

    [JsonPropertyName("grossProfit")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? GrossProfit { get; set; }

    [JsonPropertyName("incomeBeforeTax")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? IncomeBeforeTax { get; set; }

    [JsonPropertyName("incomeTaxExpense")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? IncomeTaxExpense { get; set; }

    [JsonPropertyName("interestAndDebtExpense")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? InterestAndDebtExpense { get; set; }

    [JsonPropertyName("interestExpense")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? InterestExpense { get; set; }

    [JsonPropertyName("interestIncome")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? InterestIncome { get; set; }

    [JsonPropertyName("investmentIncomeNet")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? InvestmentIncomeNet { get; set; }

    [JsonPropertyName("netIncome")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? NetIncome { get; set; }

    [JsonPropertyName("netIncomeFromContinuingOperations")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? NetIncomeFromContinuingOperations { get; set; }

    [JsonPropertyName("netInterestIncome")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? NetInterestIncome { get; set; }

    [JsonPropertyName("nonInterestIncome")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? NonInterestIncome { get; set; }

    [JsonPropertyName("operatingExpenses")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? OperatingExpenses { get; set; }

    [JsonPropertyName("operatingIncome")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? OperatingIncome { get; set; }

    [JsonPropertyName("otherNonOperatingIncome")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? OtherNonOperatingIncome { get; set; }

    // Currency string, no converter needed.
    [JsonPropertyName("reportedCurrency")]
    public string ReportedCurrency { get; set; }

    [JsonPropertyName("researchAndDevelopment")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? ResearchAndDevelopment { get; set; }

    [JsonPropertyName("sellingGeneralAndAdministrative")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? SellingGeneralAndAdministrative { get; set; }

    [JsonPropertyName("totalRevenue")]
    [JsonConverter(typeof(NoneHandlingDecimalConverter))]
    public decimal? TotalRevenue { get; set; }
}