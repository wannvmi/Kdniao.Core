using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 推送物流单号轨迹 货款状态（RequestType：107）
    /// </summary>
    public class KdApiSubscribeTrackPayment
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
        /// 订阅接口的Bk值
        /// </summary>
        public string CallBack { get; set; }

        /// <summary>
        /// 订单货款状态：1-待出款；2-已出款；3-已收款
        /// </summary>
        public string OrderState { get; set; }

        /// <summary>
        /// 返款银行卡开户人（例：**伟、*佳）
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 返款银行卡手机末四位
        /// </summary>
        public string AccountTel { get; set; }

        /// <summary>
        /// 返款银行卡末四位
        /// </summary>
        public string AccountNum { get; set; }
    }
}
