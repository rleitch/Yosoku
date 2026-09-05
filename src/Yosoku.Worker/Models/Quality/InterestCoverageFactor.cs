//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality;

//public class InterestCoverageFactor : IBaseFactor
//{
//    public string FactorName => "InterestCoverage";

//    public FactorMetric Calculate(FinancialData dataSnapshot)
//    {
//        var IS = dataSnapshot.CurrentIncomeStatement;

//        if (IS?.Ebit == null || IS.InterestAndDebtExpense == null)
//        {
//            // Not a calculable period
//            return new FactorMetric(FactorName, decimal.NaN, FactorDirection.Increase, default);
//        }

//        // Formula: EBIT / InterestAndDebtExpense
//        decimal numerator = IS.Ebit.Value;
//        decimal denominator = IS.InterestAndDebtExpense.Value;

//        // Handle division by zero to prevent runtime errors
//        decimal coverageRatio = (denominator != 0) ? (numerator / denominator) : decimal.NaN;

//        return new FactorMetric(FactorName, coverageRatio, FactorDirection.Increase, IS.FiscalDateEnding);
//    }
//}
