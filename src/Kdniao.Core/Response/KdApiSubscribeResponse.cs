using System;
using System.Collections.Generic;
using System.Text;
using Kdniao.Core.Request;

namespace Kdniao.Core.Response
{
    /// <summary>
    /// 物流信息订阅
    /// </summary>
    public class KdApiSubscribeResponse : KdniaoResponse
    {
        /// <summary>
        /// 更新时间 YYYY-MM-DD HH24:MM:SS
        /// </summary>
        public string UpdateTime { get; set; }

        /// <summary>
        /// 订单预计到货时间yyyy-mm-dd（即将上线）
        /// </summary>
        public string EstimatedDeliveryTime { get; set; }
    }
}
