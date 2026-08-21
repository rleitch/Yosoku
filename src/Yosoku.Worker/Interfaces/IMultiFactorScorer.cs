using Yosoku.Worker.Models;

namespace Yosoku.Worker.Interfaces;

public interface IMultiFactorScorer
{
    Task<List<ScoredStock>> GetTopStocksAsync(List<string> symbols, CancellationToken cancellationToken);
}