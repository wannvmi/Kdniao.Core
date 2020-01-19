using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Kdniao.Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Kdniao.Core
{
    public class KdniaoNotifyClient : IKdniaoNotifyClient
    {
        private readonly IOptions<KdniaoOptions> _options;

        public KdniaoNotifyClient(
            IOptions<KdniaoOptions> options)
        {
            _options = options;
        }

        public Task<T> ExecuteAsync<T>(HttpRequest request) where T : KdniaoNotify
        {
            return ExecuteAsync<T>(request, _options.Value);
        }

        public Task<T> ExecuteAsync<T>(HttpRequest request, KdniaoOptions options) where T : KdniaoNotify
        {
            OptionsValidate.Confirm(options);

            var requestData = new byte[request.Body.Length];
            request.Body.Read(requestData, 0, (int) request.Body.Length);
            var jsonData = Encoding.UTF8.GetString(requestData);
            T result = JsonSerializer.Deserialize<T>(jsonData);
            return Task.FromResult(result);
        }

        public IDictionary<string, string> GetParameters(HttpRequest request)
        {
            var parameters = new Dictionary<string, string>();
            if (request.Method == "POST")
            {
                foreach (var iter in request.Form)
                {
                    parameters.Add(iter.Key, iter.Value);
                }
            }
            else
            {
                foreach (var iter in request.Query)
                {
                    parameters.Add(iter.Key, iter.Value);
                }
            }
            return parameters;
        }
    }
}
