using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kdniao.Core;
using Kdniao.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Example.Aspnetcore.Controllers
{
    /// <summary>
    /// 即时查询API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class KdApiSearchController : ControllerBase
    {
        private readonly IKdniaoClient _kdniaoClient;
        private readonly IOptions<KdniaoOptions> _options;

        public KdApiSearchController(
            IKdniaoClient kdniaoClient,
            IOptions<KdniaoOptions> options)
        {
            _kdniaoClient = kdniaoClient;
            _options = options;
        }

        /// <summary>
        /// 即时查询API
        /// </summary>
        /// <param name="shipperCode">快递公司编码</param>
        /// <param name="logisticCode">物流单号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOrderTraces(string shipperCode, string logisticCode)
        {
            var model = new KdApiSearchRequest
            {
                ShipperCode = shipperCode,
                LogisticCode = logisticCode
            };
            var result = await _kdniaoClient.ExecuteAsync(model, _options.Value);

            return Ok(result);
        }
    }
}