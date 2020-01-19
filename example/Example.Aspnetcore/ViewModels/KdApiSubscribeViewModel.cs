using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kdniao.Core.Domain;

namespace Example.Aspnetcore.ViewModels
{
    public class KdApiSubscribeViewModel
    {
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 物流运单号
        /// </summary>
        public string LogisticCode { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public KdApiSender Sender { get; set; }

        /// <summary>
        /// Receiver
        /// </summary>
        public KdApiReceiver Receiver { get; set; }

    }
}
