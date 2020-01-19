using System;
using System.Collections.Generic;
using System.Text;
using Kdniao.Core.Domain;

namespace Kdniao.Core.Notify
{
    /// <summary>
    /// 订阅查询结果
    /// </summary>
    public class KdApiSubscribeNotify : KdniaoNotify
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string EBusinessID { get; set; }

        /// <summary>
        /// 推送时间
        /// </summary>
        public string PushTime { get; set; }

        /// <summary>
        /// 推送物流单号轨迹个数
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// 推送物流单号轨迹集合
        /// </summary>
        public List<KdApiSubscribeTrack> Data { get; set; }
    }
}
