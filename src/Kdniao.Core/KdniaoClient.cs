using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Kdniao.Core.Security;

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

        public async Task<T> ExecuteAsync<T>(IKdniaoRequest<T> request, KdniaoOptions options) where T : KdniaoResponse
        {
            OptionsValidate(options);

            var dataSign = Encrypt.Compute(request.GetRequestData(), options.AppKey, "UTF-8");
            var param = new KdniaoDictionary(request.GetParameters())
            {
                { "EBusinessID", options.EBusinessID },
                { "DataSign",  HttpUtility.UrlEncode(dataSign, Encoding.UTF8) },
            };
            var reqUrl = options.IsSandBox == false ? request.GetNotifyUrl() : request.GetSandBoxNotifyUrl();
            var form = new FormUrlEncodedContent(param);
            var client = _httpClientFactory.CreateClient(nameof(KdniaoClient));
            var response = await client.PostAsync(reqUrl, form);
            var result = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(result);
        }



        private void OptionsValidate(KdniaoOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrEmpty(options.EBusinessID))
            {
                throw new ArgumentNullException(nameof(options.EBusinessID));
            }

            if (string.IsNullOrEmpty(options.AppKey))
            {
                throw new ArgumentNullException(nameof(options.AppKey));
            }
        }
    }
}
