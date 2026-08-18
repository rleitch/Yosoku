namespace Yosoku.Core.Services;

public interface IFundamentalAnalysisService
{
    float CalculatePERatio(float currentPrice, float netIncome, float sharesOutstanding);
}