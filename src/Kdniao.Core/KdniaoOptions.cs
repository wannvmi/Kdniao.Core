namespace Kdniao.Core
{
    public class KdniaoOptions
    {
        /// <summary>
        /// 电商ID
        /// </summary>
        public string EBusinessID { get; set; }

        /// <summary>
        /// 电商加密私钥，快递鸟提供，注意保管，不要泄漏
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 是否为沙箱环境 默认为false
        /// </summary>
        public bool IsSandBox { get; set; } = false;
    }
}
