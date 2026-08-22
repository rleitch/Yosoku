//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality;

//public class GrossMarginStabilityFactor : IBaseFactor
//{
//    public string FactorName => "GrossMarginStability";

//    public FactorMetric Calculate(FinancialData dataSnapshot)
//    {
//        // NOTE: For a complete implementation, FinancialData needs access to 
//        // the full historical time series of IncomeStatement reports.
//        var historicalISReports = dataSnapshot.IncomeStatements;

//        if (historicalISReports == null || historicalISReports.Length < 8)
//        {
//            return new FactorMetric(FactorName, double.NaN, FactorDirection.Decrease, default);
//        }

//        // 1. Extract the last 8 Gross Margin values
//        var last8Margins = historicalISReports
//            .TakeLast(8)
//            .Select(IS => (IS.GrossProfit ?? 0.0) / (IS.TotalRevenue ?? 1.0)) // Assume TotalRevenue != 0
//            .ToList();

//        // 2. Calculate Standard Deviation (Sigma)
//        double mean = last8Margins.Average();
//        double variance = last8Margins.Sum(margin => Math.Pow(margin - mean, 2)) / last8Margins.Count;
//        double stdDev = Math.Sqrt(variance);

//        // 3. Return FactorMetric
//        // Direction: Lower sigma is better (less variation means more stability).
//        return new FactorMetric(FactorName, stdDev, FactorDirection.Decrease, historicalISReports.Last().FiscalDateEnding);
//    }
//}
