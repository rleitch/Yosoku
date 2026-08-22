//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality;

//public class EbitdaMarginFactor : IBaseFactor
//{
//    public string FactorName => "EBITDAMargin";

//    public FactorMetric Calculate(FinancialData dataSnapshot)
//    {
//        var IS = dataSnapshot.CurrentIncomeStatement;

//        if (IS?.TotalRevenue == null || IS.Ebitda == null)
//        {
//            return new FactorMetric(FactorName, double.NaN, FactorDirection.Increase, default);
//        }

//        // EBITDA / Total Revenue
//        double margin = (IS.Ebitda.Value / IS.TotalRevenue.Value);

//        return new FactorMetric(FactorName, margin, FactorDirection.Increase, IS.FiscalDateEnding);
//    }
//}
