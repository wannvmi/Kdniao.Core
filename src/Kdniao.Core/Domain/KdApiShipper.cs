using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 快递公司
    /// </summary>
    public class KdApiShipper
    {
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 快递公司名称
        /// </summary>
        public string ShipperName { get; set; }
    }
}
