using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Kdniao.Core.Utility
{
    public static class JsonUtil
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters =
            {
                new ObjectBoolConverter(),
                new BoolJsonConverter(),
                new DateTimeJsonConverter(),
            }
        };

        public static T Deserialize<T>(string body)
        {
            return JsonSerializer.Deserialize<T>(body, jsonSerializerOptions);
        }
    }
}
