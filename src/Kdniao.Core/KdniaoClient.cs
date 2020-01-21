using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Kdniao.Core.Security;
using Kdniao.Core.Utility;
using Microsoft.Extensions.Options;

namespace Kdniao.Core
{
    public class KdniaoClient : IKdniaoClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<KdniaoOptions> _options;
        public KdniaoClient(
            IHttpClientFactory httpClientFactory,
            IOptions<KdniaoOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options;
        }

        public async Task<T> ExecuteAsync<T>(IKdniaoRequest<T> request) where T : KdniaoResponse
        {
            return await ExecuteAsync(request, _options.Value);
        }

        public async Task<T> ExecuteAsync<T>(IKdniaoRequest<T> request, KdniaoOptions options) where T : KdniaoResponse
        {
            OptionsValidate.Confirm(options);

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

            return JsonUtil.Deserialize<T>(result);
        }

    }
}
