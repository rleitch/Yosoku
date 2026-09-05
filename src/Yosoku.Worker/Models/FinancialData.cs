using Yosoku.AlphaVantage.Models;

namespace Yosoku.Worker.Models;

public class FinancialData
{
    public FinancialData(
        string ticker,
        CompanyStatements<IncomeStatement> incomeStatements,
        CompanyStatements<BalanceSheet> balanceSheets,
        CompanyStatements<CashFlow> cashFlows)
    {
        Ticker = ticker;

        IncomeStatements = incomeStatements.QuarterlyReports
            .ToDictionary(q => q.FiscalDateEnding);

        var BalanceSheetsByDate = balanceSheets.QuarterlyReports
            .ToDictionary(q => q.FiscalDateEnding);

        var CashFlowsByDate = cashFlows.QuarterlyReports
            .ToDictionary(q => q.FiscalDateEnding);

        AllDates = [.. IncomeStatements.Keys];
        AllDates.UnionWith(BalanceSheetsByDate.Keys);
        AllDates.UnionWith(CashFlowsByDate.Keys);

        QuarterlySummaries = new Dictionary<DateOnly, QuarterlySummary>(AllDates.Count);

        foreach (var date in AllDates)
        {
            QuarterlySummaries.Add(
                date, 
                new QuarterlySummary(
                    date,
                    IncomeStatements.GetValueOrDefault(date),
                    BalanceSheetsByDate.GetValueOrDefault(date), 
                    CashFlowsByDate.GetValueOrDefault(date)));
        }
    }

    public string Ticker { get; set; }

    public HashSet<DateOnly> AllDates { get; set; } = [];

    public Dictionary<DateOnly, QuarterlySummary> QuarterlySummaries { get; set; } = [];

    public Dictionary<DateOnly, IncomeStatement> IncomeStatements { get; set; } = [];
}