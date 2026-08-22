//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality;

//public class DebtEquityFactor : IBaseFactor
//{
//    public string FactorName => "DebtEquityRatio";

//    public FactorMetric Calculate(FinancialData dataSnapshot)
//    {
//        var BS = dataSnapshot.CurrentBalanceSheet;

//        // Debt/Equity = (LongTermDebt + ShortTermDebt) / TotalShareholderEquity
//        if (BS?.TotalShareholderEquity == null)
//        {
//            return new FactorMetric(FactorName, double.NaN, FactorDirection.Decrease, default);
//        }

//        double longTermDebt = BS.LongTermDebt ?? 0;
//        double shortTermDebt = BS.ShortTermDebt ?? 0;
//        double totalEquity = BS.TotalShareholderEquity.Value;

//        double debt = longTermDebt + shortTermDebt;
//        double ratio = (debt / totalEquity);

//        // Direction: Lower = Better (Decrease)
//        return new FactorMetric(FactorName, ratio, FactorDirection.Decrease, BS.FiscalDateEnding);
//    }
//}