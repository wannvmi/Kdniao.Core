using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Web;
using Kdniao.Core.Domain;
using Kdniao.Core.Response;

namespace Kdniao.Core.Request
{
    /// <summary>
    /// 物流信息订阅(增值版)
    /// </summary>
    public class KdApiSubscribeMonitorRequest : IKdniaoRequest<KdApiSubscribeMonitorResponse>
    {
        /// <summary>
        /// 用户自定义回调信息。
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// 会员标识
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// 仓库标识
        /// </summary>
        public string WareHouseID { get; set; }

        /// <summary>
        /// 电子面单客户账号(与快递网点申请)
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 电子面单密码
        /// </summary>
        public string CustomerPwd { get; set; }

        /// <summary>
        /// 收件网点标识(名称)
        /// </summary>
        public string SendSite { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 物流运单号
        /// </summary>
        public string LogisticCode { get; set; }

        /// <summary>
        /// 月结编号
        /// </summary>
        public string MonthCode { get; set; }

        /// <summary>
        /// 邮费支付方式:1-现付，2-到付，3-月结，4-第三方支付
        /// </summary>
        public int PayType { get; set; } = 1;

        /// <summary>
        /// 快递类型：1-标准快件
        /// </summary>
        public int ExpType { get; set; } = 1;

        /// <summary>
        /// 快递运费
        /// </summary>
        public double Cost { get; set; } = 1.00;

        /// <summary>
        /// 其他费用
        /// </summary>
        public double OtherCost { get; set; } = 1.00;

        /// <summary>
        /// Receiver
        /// </summary>
        public KdApiReceiver Receiver { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public KdApiSender Sender { get; set; }

        /// <summary>
        /// 是否通知快递员上门揽件：0-通知;1-不通知;默认为1
        /// </summary>
        public int IsNotice { get; set; } = 1;

        /// <summary>
        /// 上门揽件时间段，格式：YYYY-MM-DD HH24:MM:SS
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 上门揽件时间段，格式：YYYY-MM-DD HH24:MM:SS
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 包裹总重量kg
        /// </summary>
        public double Weight { get; set; } = 1.00;

        /// <summary>
        /// 件数/包裹数
        /// </summary>
        public int Quantity { get; set; } = 1;

        /// <summary>
        /// 物品总体积m3
        /// </summary>
        public double Volume { get; set; } = 1.00;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否订阅短信：0-不需要；1-需要
        /// </summary>
        public int IsSendMessage { get; set; } = 0;

        /// <summary>
        /// Commodity
        /// </summary>
        public List<KdApiCommodity> Commodity { get; set; }

        /// <summary>
        /// AddService
        /// </summary>
        public List<KdApiAddService> AddService { get; set; }

        #region IKdniaoRequest
        private string _notifyUrl = "http://api.kdniao.com/api/dist";
        private string _sandBoxNotifyUrl = "http://testapi.kdniao.com:8081/api/dist";

        public string GetNotifyUrl()
        {
            return _notifyUrl;
        }

        public string GetSandBoxNotifyUrl()
        {
            return _sandBoxNotifyUrl;
        }

        public void SetNotifyUrl(string notifyUrl)
        {
            _notifyUrl = notifyUrl;
        }

        public string GetRequestData()
        {
            return JsonSerializer.Serialize(new
            {
                Callback,
                MemberID,
                WareHouseID,
                CustomerName,
                CustomerPwd,
                SendSite,
                OrderCode,
                ShipperCode,
                LogisticCode,
                MonthCode,
                PayType,
                ExpType,
                Cost,
                OtherCost,
                Receiver,
                Sender,
                IsNotice,
                StartDate,
                EndDate,
                Weight,
                Quantity,
                Volume,
                Remark,
                IsSendMessage,
                Commodity,
                AddService
            });
        }

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new Dictionary<string, string>
            {
                { "RequestData", HttpUtility.UrlEncode(GetRequestData(), Encoding.UTF8) },
                { "RequestType", ((int)KdniaoRequestType.Monitor).ToString() },
                { "DataType", "2"}
            };
            return parameters;
        }


        #endregion
    }
}
