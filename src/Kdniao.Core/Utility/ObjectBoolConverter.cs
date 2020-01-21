using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kdniao.Core.Utility
{
    public class ObjectBoolConverter : JsonConverter<object>
    {
        public override object Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.True)
            {
                return true;
            }

            if (reader.TokenType == JsonTokenType.False)
            {
                return false;
            }

            // Forward to the JsonElement converter
            var converter = options.GetConverter(typeof(JsonElement)) as JsonConverter<JsonElement>;
            if (converter != null)
            {
                return converter.Read(ref reader, type, options);
            }

            throw new JsonException();

            // or for best performance, copy-paste the code from that converter:
            //using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            //{
            //    return document.RootElement.Clone();
            //}
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException("Directly writing object not supported");
        }
    }
}
