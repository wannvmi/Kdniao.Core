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
        public virtual string EBusinessID { get; set; }

        /// <summary>
        /// 成功与否
        /// </summary>
        public virtual bool Success { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public virtual string Reason { get; set; }
    }
}
