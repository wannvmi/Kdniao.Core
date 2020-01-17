using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kdniao.Core
{
    public class KdniaoClient : IKdniaoClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public KdniaoClient(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //public async Task<T> ExecuteAsync<T>()



        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient(nameof(KdniaoClient));
        }
    }
}
