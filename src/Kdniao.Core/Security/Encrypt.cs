using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Security
{
    public static class Encrypt
    {
        ///<summary>
        ///电商Sign签名
        ///</summary>
        ///<param name="content">内容</param>
        ///<param name="keyValue">Appkey</param>
        ///<param name="charset">URL编码 </param>
        ///<returns>DataSign签名</returns>
        public static string Compute(string content, string keyValue, string charset = "UTF-8")
        {
            if (keyValue != null)
            {
                return Base64.Compute(MD5.Compute(content + keyValue, charset), charset);
            }
            return Base64.Compute(MD5.Compute(content, charset), charset);
        }
    }
}
