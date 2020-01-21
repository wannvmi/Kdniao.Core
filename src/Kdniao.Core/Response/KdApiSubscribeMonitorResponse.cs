using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Response
{
    /// <summary>
    /// 物流信息订阅(增值版)
    /// </summary>
    public class KdApiSubscribeMonitorResponse : KdniaoResponse
    {
        /// <summary>
        /// 更新时间 YYYY-MM-DD HH24:MM:SS
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 订单预计到货时间yyyy-mm-dd（即将上线）
        /// </summary>
        public string EstimatedDeliveryTime { get; set; }
    }
}
