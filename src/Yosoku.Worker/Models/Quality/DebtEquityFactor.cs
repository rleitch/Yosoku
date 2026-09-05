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
//            return new FactorMetric(FactorName, decimal.NaN, FactorDirection.Decrease, default);
//        }

//        decimal longTermDebt = BS.LongTermDebt ?? 0;
//        decimal shortTermDebt = BS.ShortTermDebt ?? 0;
//        decimal totalEquity = BS.TotalShareholderEquity.Value;

//        decimal debt = longTermDebt + shortTermDebt;
//        decimal ratio = (debt / totalEquity);

//        // Direction: Lower = Better (Decrease)
//        return new FactorMetric(FactorName, ratio, FactorDirection.Decrease, BS.FiscalDateEnding);
//    }
//}