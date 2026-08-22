using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.JsonConverterFactories;

public class NoneSafeFloatConverterFactory(
    ILogger<NoneSafeFloatConverter> logger) 
    : JsonConverterFactory
{
    public override bool CanConvert(
        Type typeToConvert)
    {
        return typeToConvert == typeof(double?);
    }

    public override JsonConverter<double?> CreateConverter(
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        return new NoneSafeFloatConverter(logger);
    }
}