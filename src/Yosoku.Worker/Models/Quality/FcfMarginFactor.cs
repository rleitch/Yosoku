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
//            return new FactorMetric(FactorName, double.NaN, FactorDirection.Increase, default);
//        }

//        double fcf = (CF.OperatingCashflow.Value - CF.CapitalExpenditures.Value);
//        double totalRevenue = IS.TotalRevenue.Value;

//        double margin = (fcf / totalRevenue);

//        return new FactorMetric(FactorName, margin, FactorDirection.Increase, IS.FiscalDateEnding);
//    }
//}