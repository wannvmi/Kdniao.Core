using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kdniao.Core;
using Kdniao.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Aspnetcore.Controllers
{
    /// <summary>
    /// 单号识别API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("单号识别API")]
    public class KdApiOrderDistinguishController : ControllerBase
    {
        private readonly IKdniaoClient _kdniaoClient;

        public KdApiOrderDistinguishController(
            IKdniaoClient kdniaoClient)
        {
            _kdniaoClient = kdniaoClient;
        }

        /// <summary>
        /// 单号识别
        /// </summary>
        /// <param name="logisticCode">物流单号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> OrderTracesSub( string logisticCode = "1234561")
        {
            var model = new KdApiOrderDistinguishRequest
            {
                LogisticCode = logisticCode
            };
            var result = await _kdniaoClient.ExecuteAsync(model);

            return Ok(result);
        }
    }
}