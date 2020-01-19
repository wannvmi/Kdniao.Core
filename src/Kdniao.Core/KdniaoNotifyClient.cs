using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Kdniao.Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<T> ExecuteAsync<T>(HttpRequest request, KdniaoOptions options) where T : KdniaoNotify
        {
            OptionsValidate.Confirm(options);
            var body = await new StreamReader(request.Body, Encoding.UTF8).ReadToEndAsync();

            T notify = JsonSerializer.Deserialize<T>(body);
            return notify;
        }

        public IActionResult Success(DateTime? updateTime = null)
        {
            return Success(_options.Value, updateTime);
        }


        public IActionResult Success(KdniaoOptions options, DateTime? updateTime = null)
        {
            var updateTimeString = updateTime.HasValue ? updateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return new ContentResult
            {
                Content = JsonSerializer.Serialize(new KdniaoNotifyResult
                {
                    EBusinessID = _options.Value.EBusinessID,
                    UpdateTime = updateTimeString,
                    Success = true,
                }),
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        public IActionResult Error(string reason = "", DateTime? updateTime = null)
        {
            return Error(_options.Value, reason, updateTime);
        }

        public IActionResult Error(KdniaoOptions options, string reason = "", DateTime? updateTime = null)
        {
            var updateTimeString = updateTime.HasValue ? updateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return new ContentResult
            {
                Content = JsonSerializer.Serialize(new KdniaoNotifyResult
                {
                    EBusinessID = _options.Value.EBusinessID,
                    UpdateTime = updateTimeString,
                    Success = false,
                    Reason = reason
                }),
                ContentType = "application/json",
                StatusCode = 200
            };
        }


    }
}
