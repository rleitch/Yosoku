namespace Yosoku.Data.Entities;

public class Record(
    string ticker, 
    DateOnly date, 
    float score, 
    float rsi,
    float peRatio,
    float sma50,
    float sma200)
{
    public string Ticker { get; private set; } = ticker;
    public DateOnly Date { get; private set; } = date;
    public float Score { get; set; } = score;
    public float Rsi { get; set; } = rsi;
    public float PeRatio { get; set; } = peRatio;
    public float Sma50 { get; set; } = sma50;
    public float Sma200 { get; set; } = sma200;
}