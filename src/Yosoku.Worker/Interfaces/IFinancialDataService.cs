using Yosoku.Worker.Models;

namespace Yosoku.Worker.Interfaces;

public interface IFinancialDataService
{
    Task<FinancialData?> GetFinancialDataAsync(string ticker, CancellationToken cancellationToken);

    Task<FinancialData[]> GetFinancialDataAsync(string[] tickers, CancellationToken cancellationToken);
}
