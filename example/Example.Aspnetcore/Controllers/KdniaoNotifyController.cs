using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Kdniao.Core;
using Kdniao.Core.Notify;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Aspnetcore.Controllers
{
    /// <summary>
    /// 快递鸟异步通知
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("快递鸟异步通知")]
    public class KdniaoNotifyController : ControllerBase
    {
        private readonly IKdniaoNotifyClient _kdniaoNotifyClient;
        private readonly ILogger<KdniaoNotifyController> _logger;

        public KdniaoNotifyController(
            IKdniaoNotifyClient kdniaoNotifyClient, 
            ILogger<KdniaoNotifyController> logger)
        {
            _kdniaoNotifyClient = kdniaoNotifyClient;
            _logger = logger;
        }

        [HttpPost("subscribenotify")]
        public async Task<IActionResult> KdApiSubscribeNotify()
        {
            try
            {

                var notify = await _kdniaoNotifyClient.ExecuteAsync<KdApiSubscribeNotify>(Request);

                return _kdniaoNotifyClient.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(ex);
            }
        }
    }
}