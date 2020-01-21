using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kdniao.Core.Utility
{
    public static class JsonUtil
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
            IgnoreNullValues = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters =
            {
                new ObjectBoolConverter(),
                new BoolJsonConverter(),
                new DateTimeJsonConverter(),
            }
        };

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);
        }

        public static async Task<T> DeserializeAsync<T>(Stream utf8Json)
        {
            return await JsonSerializer.DeserializeA    sync<T>(utf8Json, jsonSerializerOptions);
        }
    }
}
