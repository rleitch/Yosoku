//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality
//{
//    public class GrossMarginFactor : IBaseFactor
//    {
//        public string FactorName => "GrossMargin";

//        public FactorMetric Calculate(FinancialData dataSnapshot)
//        {
//            var IS = dataSnapshot.CurrentIncomeStatement; // Assumes IS is available

//            if (IS?.TotalRevenue == null || IS.CostOfGoodsAndServicesSold == null)
//            {
//                return new FactorMetric(FactorName, double.NaN, FactorDirection.Increase, default);
//            }

//            // Gross Profit / Total Revenue
//            var grossProfit = IS.GrossProfit ?? (IS.TotalRevenue ?? 0) - (IS.CostOfGoodsAndServicesSold ?? 0);
//            var totalRevenue = IS.TotalRevenue ?? 0;

//            double margin = (grossProfit / totalRevenue);

//            // Direction: Higher = Better (Increase)
//            return new FactorMetric(FactorName, margin, FactorDirection.Increase, IS.FiscalDateEnding);
//        }
//    }
//}
