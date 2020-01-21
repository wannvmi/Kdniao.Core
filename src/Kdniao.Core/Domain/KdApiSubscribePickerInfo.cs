using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 追踪监控 快递员信息
    /// </summary>
    public class KdApiSubscribePickerInfo
    {
        /// <summary>
        /// 快递员姓名
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// 快递员电话
        /// </summary>
        public string PersonTel { get; set; }

        /// <summary>
        /// 快递员工号
        /// </summary>
        public string PersonCode { get; set; }

        /// <summary>
        /// 网点名称
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 网点地址
        /// </summary>
        public string StationAddress { get; set; }

        /// <summary>
        /// 网点电话
        /// </summary>
        public string StationTel { get; set; }
    }
}
