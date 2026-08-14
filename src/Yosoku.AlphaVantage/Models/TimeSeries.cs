using System.Runtime.Serialization;

namespace Yosoku.AlphaVantage.Models;

[DataContract]
public class TimeSeries
{
    [DataMember(Name = "1. open")]
    public double Open { get; set; }

    [DataMember(Name = "2. high")]
    public double High { get; set; }

    [DataMember(Name = "3. low")]
    public double Low { get; set; }

    [DataMember(Name = "4. close")]
    public double Close { get; set; }

    [DataMember(Name = "5. adjusted close")]
    public double AdjustedClose { get; set; }

    [DataMember(Name = "6. volume")]
    public double Volume { get; set; }
}