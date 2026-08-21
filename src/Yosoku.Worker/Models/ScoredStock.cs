namespace Yosoku.Worker.Models;

public class ScoredStock
{
    public required string Symbol { get; set; }
    public float TotalScore { get; set; }
    public Dictionary<string, float> FactorScores { get; set; } = [];
}
public class StockRawData
{
    public string Symbol { get; set; } = "";
    public float QualityRaw { get; set; }
    public float ProfitRaw { get; set; }
    public float MomentumRaw { get; set; }
}