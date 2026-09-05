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
//            return new FactorMetric(FactorName, decimal.NaN, FactorDirection.Decrease, default);
//        }

//        decimal accruals = (IS.NetIncome.Value - CF.OperatingCashflow.Value);
//        decimal totalAssets = BS.TotalAssets.Value;

//        decimal ratio = (accruals / totalAssets);

//        // Direction: Lower = Better (Decrease)
//        return new FactorMetric(FactorName, ratio, FactorDirection.Decrease, IS.FiscalDateEnding);
//    }

//    // Note: The calculation for Accruals Ratio assumes that Operating Cash Flow
//    // is the primary measure of "quality" (i.e., non-cash charges are being handled).
//}
