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
    }
}