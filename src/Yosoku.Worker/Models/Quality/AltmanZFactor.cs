//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality;

//public class AltmanZFactor : IBaseFactor
//{
//    public string FactorName => "AltmanZScore";

//    public FactorMetric Calculate(FinancialData dataSnapshot)
//    {
//        var bs = dataSnapshot.CurrentBalanceSheet;
//        var IS = dataSnapshot.CurrentIncomeStatement;

//        if (bs?.TotalAssets == null || bs.TotalShareholderEquity == null || IS.Ebit == null)
//        {
//            // Return NaN if core components are missing
//            return new FactorMetric(FactorName, double.NaN, FactorDirection.Increase, default);
//        }

//        // 1. Calculate Working Capital (WC)
//        // WC = Current Assets - Current Liabilities
//        double currentAssets = bs.TotalCurrentAssets ?? 0;
//        double currentLiabilities = bs.TotalCurrentLiabilities ?? 0;
//        double wc = currentAssets - currentLiabilities;

//        // 2. Calculate Book Value of Equity (BVE)
//        // BVE = Total Shareholder Equity - Total Liabilities
//        double totalLiabilities = bs.TotalLiabilities ?? 0;
//        double bve = bs.TotalShareholderEquity.Value;

//        // 3. Apply Altman Z Formula:
//        // 6.56*WC/TA + 3.26*RE/TA + 6.72*EBIT/TA + 1.05*BVE/TL

//        // Term 1: Working Capital Ratio
//        double term1 = (wc / bs.TotalAssets.Value) * 6.56;

//        // Term 2: Retained Earnings to Total Assets Ratio
//        double retainedEarnings = bs.RetainedEarnings ?? 0;
//        double term2 = (retainedEarnings / bs.TotalAssets.Value) * 3.26;

//        // Term 3: EBIT to Total Assets Ratio
//        double term3 = (IS.Ebit.Value / bs.TotalAssets.Value) * 6.72;

//        // Term 4: Book Value of Equity to Total Liabilities Ratio
//        double term4 = (bve / totalLiabilities) * 1.05;

//        // Final Z Score
//        double zScore = term1 + term2 + term3 + term4;

//        // Direction: Higher Z Score indicates higher probability of financial distress/liquidity
//        return new FactorMetric(FactorName, zScore, FactorDirection.Increase, bs.FiscalDateEnding);
//    }
//}
