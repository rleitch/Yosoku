namespace Yosoku.AlphaVantage.Models;

public class MonthlyMarketData
{
    public DateOnly Date { get; set; }

    public float FutureTotalReturn { get; set; }

    public float PeRatio { get; set; }

    public float Sma50 { get; set; }

    public float Sma200 { get; set; }
}