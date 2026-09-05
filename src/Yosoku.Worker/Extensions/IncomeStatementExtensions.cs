using Yosoku.AlphaVantage.Models;

namespace Yosoku.Worker.Extensions;

public static class IncomeStatementExtensions
{
    public static decimal? GrossMargin(this IncomeStatement incomeStatement)
    {
        if (incomeStatement.TotalRevenue == null ||
            incomeStatement.CostOfRevenue == null ||
            incomeStatement.TotalRevenue == 0)
        {
            return null;
        }

        // Calculation: (Revenue - Cost) / Revenue
        return (incomeStatement.TotalRevenue.Value - incomeStatement.CostOfRevenue.Value) / incomeStatement.TotalRevenue.Value;
    }
}
