using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    ///   接收者
    /// wannvmi create
    /// </summary>
    public class KdApiReceiver
    {
        /// <summary>
        /// 收件人公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话(电话与手机，必填一个)
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 收件人邮编
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 收件省（如广东省，不要缺少“省”）
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 收件市（如深圳市，不要缺少“市”）
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 收件区（如福田区，不要缺少“区”或“县”）
        /// </summary>
        public string ExpAreaName { get; set; }

        /// <summary>
        /// 收件人详细地址	
        /// </summary>
        public string Address { get; set; }
    }
}
