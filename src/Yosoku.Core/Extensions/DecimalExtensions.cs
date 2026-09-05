namespace Yosoku.Core.Extensions;

public static class DecimalExtensions
{
    public static decimal? SafeDivide(this decimal? numerator, decimal? denominator)
    {
        if (numerator == null || denominator == null || denominator == 0)
        {
            return null;
        }

        return numerator.Value / denominator.Value;
    }
}