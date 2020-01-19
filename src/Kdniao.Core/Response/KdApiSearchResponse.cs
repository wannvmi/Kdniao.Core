using System;
using System.Collections.Generic;
using System.Text;
using Kdniao.Core.Domain;

namespace Kdniao.Core.Response
{
    /// <summary>
    /// 即时查询API
    /// </summary>
    public class KdApiSearchResponse : KdniaoResponse
    {
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
        /// 物流状态：2-在途中,3-签收,4-问题件
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Traces
        /// </summary>
        public List<KdApiTracesItem> Traces { get; set; }
    }
}
