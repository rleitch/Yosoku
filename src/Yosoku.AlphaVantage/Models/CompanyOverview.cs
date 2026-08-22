using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.Models
{
    public class CompanyOverview
    {
        public required string Symbol { get; set; }
        public required string AssetType { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string CIK { get; set; }
        public required string Exchange { get; set; }
        public required string Currency { get; set; }
        public required string Country { get; set; }
        public required string Sector { get; set; }
        public required string Industry { get; set; }
        public required string Address { get; set; }
        public required string OfficialSite { get; set; }
        public required string FiscalYearEnd { get; set; }
        public required string LatestQuarter { get; set; }
        public double MarketCapitalization { get; set; }
        public double? EBITDA { get; set; }
        public double? PERatio { get; set; }
        public double? PEGRatio { get; set; }
        public double? BookValue { get; set; }
        public double? DividendPerShare { get; set; }
        public double? DividendYield { get; set; }
        public double? EPS { get; set; }
        public double RevenuePerShareTTM { get; set; }
        public double ProfitMargin { get; set; }
        public double OperatingMarginTTM { get; set; }
        public double ReturnOnAssetsTTM { get; set; }
        public double ReturnOnEquityTTM { get; set; }
        public double RevenueTTM { get; set; }
        public double GrossProfitTTM { get; set; }
        public double DilutedEPSTTM { get; set; }
        public double QuarterlyEarningsGrowthYOY { get; set; }
        public double QuarterlyRevenueGrowthYOY { get; set; }
        public required string AnalystRatingStrongBuy { get; set; }
        public required string AnalystRatingBuy { get; set; }
        public required string AnalystRatingHold { get; set; }
        public required string AnalystRatingSell { get; set; }
        public required string AnalystRatingStrongSell { get; set; }
        public double? TrailingPE { get; set; }
        public double? ForwardPE { get; set; }
        public double PriceToSalesRatioTTM { get; set; }
        public double? PriceToBookRatio { get; set; }
        public double EVToRevenue { get; set; }
        public double? EVToEBITDA { get; set; }
        public double? Beta { get; set; }

        [JsonPropertyName("52WeekHigh")]
        public double Week52High { get; set; }

        [JsonPropertyName("52WeekLow")]
        public double Week52Low { get; set; }

        [JsonPropertyName("50DayMovingAverage")]
        public double Day50MovingAverage { get; set; }

        [JsonPropertyName("200DayMovingAverage")]
        public double Day200MovingAverage { get; set; }

        public double SharesOutstanding { get; set; }
        public double SharesFloat { get; set; }
        public double PercentInsiders { get; set; }
        public double PercentInstitutions { get; set; }
        public required string DividendDate { get; set; }
        public required string ExDividendDate { get; set; }
    }
}
