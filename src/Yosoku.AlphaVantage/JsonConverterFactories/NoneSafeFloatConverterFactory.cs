using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.JsonConverters;

namespace Yosoku.AlphaVantage.JsonConverterFactories;

public class NoneSafeFloatConverterFactory(
    ILogger<NoneSafeDecimalConverter> logger) 
    : JsonConverterFactory
{
    public override bool CanConvert(
        Type typeToConvert)
    {
        return typeToConvert == typeof(decimal?);
    }

    public override JsonConverter<decimal?> CreateConverter(
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        return new NoneSafeDecimalConverter(logger);
    }
}