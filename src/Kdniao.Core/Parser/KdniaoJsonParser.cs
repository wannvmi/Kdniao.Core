using System.Text.Encodings.Web;
using System.Text.Json;

namespace Kdniao.Core.Parser
{
    public class KdniaoJsonParser<T> : IKdniaoJsonParser<T> where T : KdniaoResponse
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //Converters =
            //{
            //    new ObjectBoolConverter()
            //}
        };

        public T Parse(string body)
        {
            return JsonSerializer.Deserialize<T>(body, jsonSerializerOptions);
        }
    }
}
