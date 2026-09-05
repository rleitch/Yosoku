namespace Yosoku.Data.Entities;

public class Record(
    string ticker, 
    DateOnly date, 
    decimal score, 
    decimal rsi,
    decimal peRatio,
    decimal sma50,
    decimal sma200)
{
    public string Ticker { get; private set; } = ticker;
    public DateOnly Date { get; private set; } = date;
    public decimal Score { get; set; } = score;
    public decimal Rsi { get; set; } = rsi;
    public decimal PeRatio { get; set; } = peRatio;
    public decimal Sma50 { get; set; } = sma50;
    public decimal Sma200 { get; set; } = sma200;
}