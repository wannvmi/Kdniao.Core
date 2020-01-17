using System;
using System.Collections.Generic;
using System.Text;
using Kdniao.Core.Domain;

namespace Kdniao.Core.Response
{
    /// <summary>
    /// 即时查询API
    /// </summary>
    public class KdApiSearchResponse : KdniaoResponse
    {
        /// <summary>
        /// 物流状态：2-在途中,3-签收,4-问题件
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Traces
        /// </summary>
        public List<KdApiSearchTraces> Traces { get; set; }
    }
}
