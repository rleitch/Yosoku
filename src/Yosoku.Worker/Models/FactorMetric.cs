namespace Yosoku.Worker.Models;

public record FactorMetric(
    string Name,
    decimal? Value,
    FactorDirection Direction,
    DateOnly CalculationDate
);