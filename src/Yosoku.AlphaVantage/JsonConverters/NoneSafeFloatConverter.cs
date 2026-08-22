using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.JsonConverters;

public class NoneSafeFloatConverter(ILogger<NoneSafeFloatConverter> logger) : JsonConverter<double?>
{
    public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? jsonString = reader.GetString();

        if (string.IsNullOrEmpty(jsonString) 
            || string.Equals("None", jsonString, StringComparison.OrdinalIgnoreCase) 
            || string.Equals("-", jsonString, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        if (double.TryParse(jsonString, out double result))
        {
            return result;
        }

        logger.LogWarning($"Could not parse '{jsonString}' into a double.");
        return null;
    }

    public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Writing is not implemented for NoneSafeFloatConverter.");
    }
}