using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.JsonConverters;

public class NoneSafeDecimalConverter(ILogger<NoneSafeDecimalConverter> logger) : JsonConverter<decimal?>
{
    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? jsonString = reader.GetString();

        if (string.IsNullOrEmpty(jsonString) 
            || string.Equals("None", jsonString, StringComparison.OrdinalIgnoreCase) 
            || string.Equals("-", jsonString, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        if (decimal.TryParse(jsonString, out decimal result))
        {
            return result;
        }

        logger.LogWarning($"Could not parse '{jsonString}' into a decimal.");
        return null;
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Writing is not implemented for NoneSafeFloatConverter.");
    }
}