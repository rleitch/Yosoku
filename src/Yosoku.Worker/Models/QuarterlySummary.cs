using Yosoku.AlphaVantage.Models;
using Yosoku.Core.Extensions;
using Yosoku.Worker.Extensions;

namespace Yosoku.Worker.Models;

public class QuarterlySummary(
    DateOnly fiscalDateEnding,
    IncomeStatement? incomeStatement,
    BalanceSheet? balanceSheet,
    CashFlow? cashFlow)
{
    public DateOnly FiscalDateEnding { get; init; } = fiscalDateEnding;

    public IncomeStatement? IncomeStatement { get; init; } = incomeStatement;

    public BalanceSheet? BalanceSheet { get; init; } = balanceSheet;

    public CashFlow? CashFlow { get; init; } = cashFlow;

    private decimal? _grossMargin = null;

    public decimal? GrossMargin
    {
        get => _grossMargin ??= IncomeStatement?.GrossMargin();
    }
}