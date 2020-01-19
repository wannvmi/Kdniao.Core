using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Aspnetcore.ViewModels;
using Kdniao.Core;
using Kdniao.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Aspnetcore.Controllers
{
    /// <summary>
    /// 查询类接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [SwaggerTag("查询类接口")]
    public class LogisticsInquiryController : ControllerBase
    {
        private readonly IKdniaoClient _kdniaoClient;
        public LogisticsInquiryController(IKdniaoClient kdniaoClient)
        {
            _kdniaoClient = kdniaoClient;
        }

        /// <summary>
        /// 即时查询API
        /// </summary>
        /// <param name="shipperCode">快递公司编码</param>
        /// <param name="logisticCode">物流单号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> KdApiSearch(string shipperCode = "SF", string logisticCode = "1234561")
        {
            var model = new KdApiSearchRequest
            {
                ShipperCode = shipperCode,
                LogisticCode = logisticCode
            };
            var result = await _kdniaoClient.ExecuteAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 物流跟踪API
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> KdApiSubscribe([FromBody] KdApiSubscribeViewModel model)
        {
            var request = new KdApiSubscribeRequest
            {
                ShipperCode = model.ShipperCode,
                LogisticCode = model.LogisticCode,
                Sender = model.Sender,
                Receiver = model.Receiver
            };
            var result = await _kdniaoClient.ExecuteAsync(request);

            return Ok(result);
        }

        /// <summary>
        /// 在途监控：即时查询(增值版)接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> KdApiSearchMonitor(string shipperCode = "SF", string logisticCode = "1234561")
        {
            var model = new KdApiSearchMonitorRequest
            {
                ShipperCode = shipperCode,
                LogisticCode = logisticCode
            };
            var result = await _kdniaoClient.ExecuteAsync(model);

            return Ok(result);
        }
    }
}