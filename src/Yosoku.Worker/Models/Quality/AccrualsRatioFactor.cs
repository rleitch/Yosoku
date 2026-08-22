//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality;

//public class AccrualsRatioFactor : IBaseFactor
//{
//    public string FactorName => "AccrualsRatio";

//    public FactorMetric Calculate(FinancialData dataSnapshot)
//    {
//        var IS = dataSnapshot.CurrentIncomeStatement;
//        var CF = dataSnapshot.CurrentCashFlow;
//        var BS = dataSnapshot.CurrentBalanceSheet;

//        // Accruals Ratio = (NetIncome - OperatingCashflow) / TotalAssets
//        if (IS?.NetIncome == null || CF?.OperatingCashflow == null || BS?.TotalAssets == null)
//        {
//            return new FactorMetric(FactorName, double.NaN, FactorDirection.Decrease, default);
//        }

//        double accruals = (IS.NetIncome.Value - CF.OperatingCashflow.Value);
//        double totalAssets = BS.TotalAssets.Value;

//        double ratio = (accruals / totalAssets);

//        // Direction: Lower = Better (Decrease)
//        return new FactorMetric(FactorName, ratio, FactorDirection.Decrease, IS.FiscalDateEnding);
//    }

//    // Note: The calculation for Accruals Ratio assumes that Operating Cash Flow
//    // is the primary measure of "quality" (i.e., non-cash charges are being handled).
//}
