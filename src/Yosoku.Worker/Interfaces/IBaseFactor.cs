using Yosoku.Worker.Models;

namespace Yosoku.Worker.Interfaces;

public interface IBaseFactor
{
    string FactorName { get; }

    FactorMetric Calculate(FinancialData dataSnapshot);
}
