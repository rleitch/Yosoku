using System.Runtime.Serialization;

namespace Yosoku.AlphaVantage.Models;

[DataContract]
public class MetaData
{
    [DataMember(Name = "1. Information")]
    public required string Information { get; set; }

    [DataMember(Name = "2. Symbol")]
    public required string Symbol { get; set; }

    [DataMember(Name = "3. Last Refreshed")]
    public required string LastRefreshed { get; set; }

    [DataMember(Name = "4. Time Zone")]
    public required string TimeZone { get; set; }
}