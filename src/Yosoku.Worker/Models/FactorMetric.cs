namespace Yosoku.Worker.Models;

public record FactorMetric(
    string Name,                       // e.g., "GrossMargin"
    double Value,                      // The calculated ratio
    FactorDirection Direction,        // True if higher is better, False if lower is better
    DateOnly CalculationDate         // The specific reporting period (using DateOnly)
);