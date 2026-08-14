using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yosoku.AlphaVantage.JsonConverters;

public class NoneHandlingDecimalConverter : JsonConverter<decimal?>
{
    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null || string.IsNullOrEmpty(reader.GetString()))
        {
            return null;
        }

        string jsonString = reader.GetString();

        if (string.Equals("None", jsonString, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        if (decimal.TryParse(jsonString, out decimal result))
        {
            return result;
        }

        Console.WriteLine($"Warning: Could not parse '{jsonString}' into a decimal.");
        return null;
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
    {
        writer.WriteNullValue();
    }
}