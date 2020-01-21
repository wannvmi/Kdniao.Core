using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 推送物流单号轨迹 订阅查询(增值版)结果（RequestType：102）
    /// </summary>
    public class KdApiSubscribeMonitorTrack
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string EBusinessID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 物流运单号
        /// </summary>
        public string LogisticCode { get; set; }

        /// <summary>
        /// 成功与否
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 物流状态:0-无轨迹,1-已揽收, 2-在途中 201-到达派件城市，3-签收,4-问题件
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 增值物流状态： 1-已揽收， 2-在途中， 201-到达派件城市， 202-派件中， 211-已放入快递柜或驿站， 3-已签收， 311-已取出快递柜或驿站， 4-问题件， 401-发货无信息， 402-超时未签收， 403-超时未更新， 404-拒收（退件）， 412-快递柜或驿站超时未取
        /// </summary>
        public string StateEx { get; set; }

        /// <summary>
        /// 增值所在城市
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 订阅接口的Bk值
        /// </summary>
        public string CallBack { get; set; }

        /// <summary>
        /// Traces
        /// </summary>
        public List<KdApiTracesMonitorItem> Traces { get; set; }

        /// <summary>
        /// 预计到达时间yyyy-mm-dd
        /// </summary>
        public string EstimatedDeliveryTime { get; set; }

        /// <summary>
        /// PickerInfo
        /// </summary>
        public KdApiSubscribePickerInfo PickerInfo { get; set; }

        /// <summary>
        /// SenderInfo
        /// </summary>
        public KdApiSubscribeSenderInfo SenderInfo { get; set; }
    }
}
