using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace KdGoldAPI
{
    public class KdApiExpRecommend
    {
        //电商ID
        private string EBusinessID = "请到快递鸟官网申请http://www.kdniao.com/ServiceApply.aspx";
        //电商加密私钥，快递鸟提供，注意保管，不要泄漏
        private string AppKey = "请到快递鸟官网申请http://www.kdniao.com/ServiceApply.aspx";
        //请求url
        //测试环境
        private string ReqURL = "http://testapi.kdniao.com:8081/Ebusiness/EbusinessOrderHandle.aspx";
        //正式环境
        //private string ReqURL = "http://api.kdniao.com/Ebusiness/EbusinessOrderHandle.aspx";

        /// <summary>
        /// Json方式 智选物流
        /// </summary>
        /// <returns></returns>
        public string getExpRecommendByJson()
        {
            string requestData = "{'MemberID':'123456','WarehouseID':'1','Detail':[{'OrderCode':'12345','IsCOD':0,'Sender':{'ProvinceName':'广东省','CityName':'广州','ExpAreaName':'龙岗区','Subdistrict':'布吉街道','Address':'518000'},'Receiver':{'ProvinceName':'广东','CityName':'梅州','ExpAreaName':'丰顺','Subdistrict':'布吉街道','Address':'518000'},'Goods':[{'ProductName':'包','Volume':'','Weight':'1'}]},{'OrderCode':'12346','IsCOD':0,'Sender':{'ProvinceName':'广东省','CityName':'广州','ExpAreaName':'龙岗区','Subdistrict':'布吉街道','Address':'518000'},'Receiver':{'ProvinceName':'湖南','CityName':'长沙','ExpAreaName':'龙岗区','Subdistrict':'布吉街道','Address':'518000'},'Goods':[{'ProductName':'包','Volume':'','Weight':'1'}]}]}";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "2006");
            string dataSign = encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            string result = sendPost(ReqURL, param);

            //根据公司业务处理返回的信息......

            return result;
        }

		/// <summary>
        /// Json方式 运费模板导入
        /// </summary>
        /// <returns></returns>
		public string importCostTemplateByJson()
        {
            string requestData = "{'MemberID':'123456','Detail':[{'ShipperCode':'YD','SendProvince':'广东','SendCity':'广州','SendExpArea':'天河','ReceiveProvince':'湖南','ReceiveCity':'长沙','ReceiveExpArea':'龙岗','FirstWeight':'1','FirstFee':'8','AdditionalWeight':'1','AdditionalFee':'10','WeightFormula':''},{'ShipperCode':'YD','SendProvince':'广东','SendCity':'广州','SendExpArea':'天河','ReceiveProvince':'湖南','ReceiveCity':'长沙','ReceiveExpArea':'雨花','FirstWeight':'1','FirstFee':'8','AdditionalWeight':'1','AdditionalFee':'10','WeightFormula':'{{w-0}-0.4}*{{{1000-w}-0.4}+1}*4.700+ {{w-1000}-0.6}*[(w-1000)/1000]*4.700）','ShippingType':'1','IntervalList':[{'StartWeight': 1.0,'EndWeight': 2.0, 'Fee': 3.0}]}]}";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "2004");
            string dataSign = encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            string result = sendPost(ReqURL, param);

            //根据公司业务处理返回的信息......

            return result;
        }

        /// <summary>
        /// Post方式提交数据，返回网页的源代码
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="param">请求的参数集合</param>
        /// <returns>远程资源的响应结果</returns>
        private string sendPost(string url, Dictionary<string, string> param)
        {
            string result = "";
            StringBuilder postData = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                foreach (var p in param)
                {
                    if (postData.Length > 0)
                    {
                        postData.Append("&");
                    }
                    postData.Append(p.Key);
                    postData.Append("=");
                    postData.Append(p.Value);
                }
            }
            byte[] byteData = Encoding.GetEncoding("UTF-8").GetBytes(postData.ToString());
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Referer = url;
                request.Accept = "*/*";
                request.Timeout = 30 * 1000;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.Method = "POST";
                request.ContentLength = byteData.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(byteData, 0, byteData.Length);
                stream.Flush();
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream backStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(backStream, Encoding.GetEncoding("UTF-8"));
                result = sr.ReadToEnd();
                sr.Close();
                backStream.Close();
                response.Close();
                request.Abort();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        ///<summary>
        ///电商Sign签名
        ///</summary>
        ///<param name="content">内容</param>
        ///<param name="keyValue">Appkey</param>
        ///<param name="charset">URL编码 </param>
        ///<returns>DataSign签名</returns>
        private string encrypt(String content, String keyValue, String charset)
        {
            if (keyValue != null)
            {
                return base64(MD5(content + keyValue, charset), charset);
            }
            return base64(MD5(content, charset), charset);
        }

        ///<summary>
        /// 字符串MD5加密
        ///</summary>
        ///<param name="str">要加密的字符串</param>
        ///<param name="charset">编码方式</param>
        ///<returns>密文</returns>
        private string MD5(string str, string charset)
        {
            byte[] buffer = System.Text.Encoding.GetEncoding(charset).GetBytes(str);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider check;
                check = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] somme = check.ComputeHash(buffer);
                string ret = "";
                foreach (byte a in somme)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("X");
                    else
                        ret += a.ToString("X");
                }
                return ret.ToLower();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="str">内容</param>
        /// <param name="charset">编码方式</param>
        /// <returns></returns>
        private string base64(String str, String charset)
        {
            return Convert.ToBase64String(System.Text.Encoding.GetEncoding(charset).GetBytes(str));
        }
    }
}