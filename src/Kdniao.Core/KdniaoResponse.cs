using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core
{
    /// <summary>
    /// json 响应
    /// </summary>
    public abstract class KdniaoResponse
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string EBusinessID { get; set; }

        /// <summary>
        /// 成功与否
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }
    }
}
