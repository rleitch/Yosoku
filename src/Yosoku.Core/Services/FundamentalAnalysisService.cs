namespace Yosoku.Core.Services;

public static class FundamentalAnalysisService
{
    public static double CalculatePERatio(double currentPrice, double netIncome, double sharesOutstanding)
    {
        if (netIncome == 0f)
        {
            return double.PositiveInfinity;
        }

        if (sharesOutstanding == 0f)
        {
            throw new ArgumentException("Shares outstanding cannot be zero.");
        }

        return (currentPrice * sharesOutstanding) / netIncome;
    }
}