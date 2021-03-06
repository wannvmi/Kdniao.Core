﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 追踪监控
    /// </summary>
    public class KdApiTracesItem
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime AcceptTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string AcceptStation { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
