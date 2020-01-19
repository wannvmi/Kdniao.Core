using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Domain
{
    /// <summary>
    /// 商品
    /// </summary>
    public class KdApiCommodity
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string GoodsCode { get; set; }

        /// <summary>
        /// 件数
        /// </summary>
        public int Goodsquantity { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public string GoodsPrice { get; set; }

        /// <summary>
        /// 商品重量kg
        /// </summary>
        public string GoodsWeight { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string GoodsDesc { get; set; }

        /// <summary>
        /// 商品体积m3
        /// </summary>
        public string GoodsVol { get; set; }
    }
}
