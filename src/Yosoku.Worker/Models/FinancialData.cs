using Yosoku.AlphaVantage.Models;

namespace Yosoku.Worker.Models;

public class FinancialData
{
    public required IncomeStatement[] IncomeStatements { get; init; }

    public required IncomeStatement CurrentIncomeStatement { get; init; }

    public required BalanceSheet[] BalanceSheets { get; init; }

    public required BalanceSheet CurrentBalanceSheet { get; init; }

    public required CashFlow[] CashFlows { get; init; }

    public required CashFlow CurrentCashFlow { get; init; }
}