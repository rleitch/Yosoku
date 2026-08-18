namespace Yosoku.AlphaVantage.Models;

public class MarketData
{
    public required string Symbol { get; set; }

    public TimeSeriesResponse? MonthlyData { get; set; }

    public TimeSeriesResponse? DailyData { get; set; }

    public CompanyStatements<IncomeStatement>? IncomeStatement { get; set; }

    public CompanyStatements<BalanceSheet>? BalanceSheet { get; set; }

    public List<MonthlyMarketData> MonthlyMarketData { get; set; } = [];
}