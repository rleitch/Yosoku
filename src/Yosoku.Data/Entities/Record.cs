namespace Yosoku.Data.Entities;

public class Record(
    string ticker, 
    DateOnly date, 
    double score, 
    double rsi,
    double peRatio,
    double sma50,
    double sma200)
{
    public string Ticker { get; private set; } = ticker;
    public DateOnly Date { get; private set; } = date;
    public double Score { get; set; } = score;
    public double Rsi { get; set; } = rsi;
    public double PeRatio { get; set; } = peRatio;
    public double Sma50 { get; set; } = sma50;
    public double Sma200 { get; set; } = sma200;
}