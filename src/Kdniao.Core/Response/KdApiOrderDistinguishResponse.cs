using System;
using System.Collections.Generic;
using System.Text;
using Kdniao.Core.Domain;

namespace Kdniao.Core.Response
{
    /// <summary>
    /// 单号识别API
    /// </summary>
    public class KdApiOrderDistinguishResponse : KdniaoResponse
    {
        /// <summary>
        /// 失败原因
        /// </summary>
        public int? Code { get; set; }

        public List<KdApiShipper> Shippers { get; set; }
    }
}
