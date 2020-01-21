using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 增值服务
    /// </summary>
    public class KdApiAddService
    {
        /// <summary>
        /// 增值服务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 增值服务值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 客户标识
        /// </summary>
        public string CustomerID { get; set; }
    }
}
