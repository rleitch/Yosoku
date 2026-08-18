using Yosoku.AlphaVantage.Models;

namespace Yosoku.AlphaVantage;

public interface IAlphaVantageClient
{
    Task<TimeSeriesResponse> TimeSeriesDailyAsync(string symbol, CancellationToken token);
    Task<TimeSeriesResponse> TimeSeriesMonthlyAsync(string symbol, CancellationToken token);
    Task<CompanyStatements<IncomeStatement>> GetIncomeStatements(string symbol, CancellationToken token);
    Task<CompanyStatements<BalanceSheet>> GetBalanceSheets(string symbol, CancellationToken token);
    Task<EtfProfile> GetEtfProfile(string symbol, CancellationToken token);
}