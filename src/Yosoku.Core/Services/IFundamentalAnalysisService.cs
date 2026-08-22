namespace Yosoku.Core.Services;

public interface IFundamentalAnalysisService
{
    double CalculatePERatio(double currentPrice, double netIncome, double sharesOutstanding);
}