using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KdniaoWebsite.WebUI.External
{
    public partial class PrintExample : System.Web.UI.Page
    {
        //电商ID,对应快递鸟EBusinessID
        private string ID = "EBusinessID";
        //电商加密私钥，快递鸟提供，注意保管，不要泄漏
        private string APIKey = "F204758A-513B-4647-98D6-19DE7EA75B23";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //OrderCode:需要打印的订单号，和调用快递鸟电子面单的订单号一致，PortName：本地打印机名称，请参考使用手册设置打印机名称。支持多打印机同时打印。
                var requestData = "[{\"OrderCode\":\"234351215333113311353\",\"PortName\":\"打印机名称一\"},{\"OrderCode\":\"234351215333113311354\",\"PortName\":\"打印机名称二\"}]";

                RequestData.Value = HttpUtility.UrlEncode(requestData, Encoding.UTF8);

                EBusinessID.Value = ID;

                DataSign.Value = Encrypt(GetIp() + requestData, APIKey, "UTF-8");


                //是否预览，0-不预览 1-预览
                IsPreview.Value = "0";
            }
        }
        private string Encrypt(String content, String keyValue, String charset)
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
        private static string GetIp()
        {
            var ip = string.Empty;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];
            }
            else
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            //如服务端与客户端在同一网络，则ip会得到内网ip，需通过外网获取客户端ip
            if (string.IsNullOrEmpty(ip) || ip == "::1" || IsInnerIP(ip))
            {
                string url = "http://www.kdniao.com/External/GetIp.ashx";
                try
                {
                    //从网址中获取本机ip数据    
                    System.Net.WebClient client = new System.Net.WebClient();
                    client.Encoding = System.Text.Encoding.Default;
                    string str = client.DownloadString(url);
                    client.Dispose();
                    if (!str.Equals("")) ip = str;
                }
                catch (Exception)
                {

                }
            }

            return ip;
        }

        public static bool IsInnerIP(String ipAddress)
        {
            bool isInnerIp = false;
            long ipNum = GetIpNum(ipAddress);
            long aBegin = GetIpNum("10.0.0.0");
            long aEnd = GetIpNum("10.255.255.255");
            long bBegin = GetIpNum("172.16.0.0");
            long bEnd = GetIpNum("172.31.255.255");
            long cBegin = GetIpNum("192.168.0.0");
            long cEnd = GetIpNum("192.168.255.255");
            isInnerIp = IsInner(ipNum, aBegin, aEnd) || IsInner(ipNum, bBegin, bEnd) || IsInner(ipNum, cBegin, cEnd) || ipAddress.Equals("127.0.0.1");
            return isInnerIp;
        }
        private static long GetIpNum(String ipAddress)
        {
            String[] ip = ipAddress.Split('.');
            long a = int.Parse(ip[0]);
            long b = int.Parse(ip[1]);
            long c = int.Parse(ip[2]);
            long d = int.Parse(ip[3]);

            long ipNum = a * 256 * 256 * 256 + b * 256 * 256 + c * 256 + d;
            return ipNum;
        }
        private static bool IsInner(long userIp, long begin, long end)
        {
            return (userIp >= begin) && (userIp <= end);
        }
    }
}