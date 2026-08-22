//using Yosoku.Worker.Interfaces;

//namespace Yosoku.Worker.Models.Quality;

//public class QualityPillar
//{
//    private readonly IEnumerable<IBaseFactor> _subFactors;

//    public QualityPillar()
//    {
//        // Initialize all Quality sub-factors
//        _subFactors =
//            [
//            new AccrualsRatioFactor(),
//            new AltmanZFactor(),
//            new DebtEquityFactor(),
//            new EbitdaMarginFactor(),
//            new FcfMarginFactor(),
//            new GrossMarginFactor(),
//            new GrossMarginStabilityFactor(),
//            new InterestCoverageFactor()
//            ];
//    }

//    public IEnumerable<FactorMetric> CalculateAllMetrics(FinancialData dataSnapshot)
//    {
//        // Calculate every sub-factor metric for the latest available period
//        return [.. _subFactors.Select(f => f.Calculate(dataSnapshot))];
//    }
//}
