using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.JsonConverters;

public class NoneSafeDoubleConverter : JsonConverter<double?>
{
    public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? jsonString = reader.GetString();

        if (string.IsNullOrEmpty(jsonString))
        {
            return null;
        }

        if (string.Equals("None", jsonString, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        if (double.TryParse(jsonString, out double result))
        {
            return result;
        }

        Console.WriteLine($"Warning: Could not parse '{jsonString}' into a double.");
        return null;
    }

    public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
    {
        writer.WriteNullValue();
    }
}