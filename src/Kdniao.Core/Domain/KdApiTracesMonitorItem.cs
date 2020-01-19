using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 追踪监控
    /// </summary>
    public class KdApiTracesMonitorItem
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string AcceptTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string AcceptStation { get; set; }

        /// <summary>
        /// 当前城市
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
