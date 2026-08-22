namespace Yosoku.Worker.Models;

public class ScoredStock
{
    public required string Symbol { get; set; }
    public double TotalScore { get; set; }
    public Dictionary<string, double> FactorScores { get; set; } = [];
}
public class StockRawData
{
    public string Symbol { get; set; } = "";
    public double QualityRaw { get; set; }
    public double ProfitRaw { get; set; }
    public double MomentumRaw { get; set; }
}