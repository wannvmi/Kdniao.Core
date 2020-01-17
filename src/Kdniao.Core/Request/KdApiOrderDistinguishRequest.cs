using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Web;
using Kdniao.Core.Response;

namespace Kdniao.Core.Request
{
    /// <summary>
    /// 单号识别API
    /// </summary>
    public class KdApiOrderDistinguishRequest : IKdniaoRequest<KdApiOrderDistinguishResponse>
    {
        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticCode { get; set; }

        #region IKdniaoRequest
        private string _notifyUrl = "http://api.kdniao.com/Ebusiness/EbusinessOrderHandle.aspx";
        private string _sandBoxNotifyUrl = "http://sandboxapi.kdniao.com:8080/kdniaosandbox/gateway/exterfaceInvoke.json";

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
                LogisticCode = LogisticCode
            });
        }

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new Dictionary<string, string>
            {
                { "RequestData", HttpUtility.UrlEncode(GetRequestData(), Encoding.UTF8) },
                { "RequestType", "2002" },
                { "DataType", "2"}
            };
            return parameters;
        }


        #endregion
    }
}
