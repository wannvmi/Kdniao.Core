using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 追踪监控 派件员信息
    /// </summary>
    public class KdApiSubscribeSenderInfo
    {
        /// <summary>
        /// 派件员姓名
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// 派件员电话
        /// </summary>
        public string PersonTel { get; set; }

        /// <summary>
        /// 派件员工号
        /// </summary>
        public string PersonCode { get; set; }

        /// <summary>
        /// 派件网点名称
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 派件网点地址
        /// </summary>
        public string StationAddress { get; set; }

        /// <summary>
        /// 派件网点电话
        /// </summary>
        public string StationTel { get; set; }
    }
}
