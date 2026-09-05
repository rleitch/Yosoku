//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality;

//public class FcfMarginFactor : IBaseFactor
//{
//    public string FactorName => "FCFMagnitude";

//    public FactorMetric Calculate(FinancialData dataSnapshot)
//    {
//        var CF = dataSnapshot.CurrentCashFlow; // Assumes CF is available
//        var IS = dataSnapshot.CurrentIncomeStatement;

//        // FCF = (OperatingCashflow - CapitalExpenditures) / TotalRevenue
//        if (CF?.OperatingCashflow == null || CF.CapitalExpenditures == null || IS?.TotalRevenue == null)
//        {
//            return new FactorMetric(FactorName, decimal.NaN, FactorDirection.Increase, default);
//        }

//        decimal fcf = (CF.OperatingCashflow.Value - CF.CapitalExpenditures.Value);
//        decimal totalRevenue = IS.TotalRevenue.Value;

//        decimal margin = (fcf / totalRevenue);

//        return new FactorMetric(FactorName, margin, FactorDirection.Increase, IS.FiscalDateEnding);
//    }
//}