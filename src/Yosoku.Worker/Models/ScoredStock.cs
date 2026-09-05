namespace Yosoku.Worker.Models;

public class ScoredStock
{
    public required string Symbol { get; set; }
    public decimal TotalScore { get; set; }
    public Dictionary<string, decimal> FactorScores { get; set; } = [];
}
public class StockRawData
{
    public string Symbol { get; set; } = "";
    public decimal QualityRaw { get; set; }
    public decimal ProfitRaw { get; set; }
    public decimal MomentumRaw { get; set; }
}