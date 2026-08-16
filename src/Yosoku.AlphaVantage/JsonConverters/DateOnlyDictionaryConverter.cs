using System.Text.Json;
using System.Text.Json.Serialization;
using Yosoku.AlphaVantage.Models;

namespace Yosoku.AlphaVantage.JsonConverters;

public class DateOnlyDictionaryConverter : JsonConverter<Dictionary<DateOnly, TimeSeries>>
{
    public override Dictionary<DateOnly, TimeSeries> Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var dictionary = new Dictionary<DateOnly, TimeSeries>();

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
                    var value = JsonSerializer.Deserialize<TimeSeries>(ref reader, options);
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
        Dictionary<DateOnly, TimeSeries> value, 
        JsonSerializerOptions options)
    {
        throw new NotImplementedException("Writing is not implemented.");
    }
}