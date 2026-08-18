namespace Yosoku.Core.Services;

public static class FundamentalAnalysisService
{
    public static float CalculatePERatio(float currentPrice, float netIncome, float sharesOutstanding)
    {
        if (netIncome == 0f)
        {
            return float.PositiveInfinity;
        }

        if (sharesOutstanding == 0f)
        {
            throw new ArgumentException("Shares outstanding cannot be zero.");
        }

        return (currentPrice * sharesOutstanding) / netIncome;
    }
}