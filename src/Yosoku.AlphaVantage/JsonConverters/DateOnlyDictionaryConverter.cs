using System.Text.Json;
using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.Models;

namespace Yosoku.AlphaVantage.JsonConverters;

public class DateOnlyDictionaryConverter : JsonConverter<Dictionary<DateOnly, Quote>>
{
    public override Dictionary<DateOnly, Quote> Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var dictionary = new Dictionary<DateOnly, Quote>();

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                string? keyString = reader.GetString();
                reader.Read();
                if (DateOnly.TryParse(keyString, out DateOnly date))
                {
                    var value = JsonSerializer.Deserialize<Quote>(ref reader, options);
                    if(value != null)
                    {
                        dictionary.Add(date, value);
                    }
                }
            }
        }
        return dictionary;
    }

    public override void Write(
        Utf8JsonWriter writer, 
        Dictionary<DateOnly, Quote> value, 
        JsonSerializerOptions options)
    {
        throw new NotImplementedException("Writing is not implemented.");
    }
}