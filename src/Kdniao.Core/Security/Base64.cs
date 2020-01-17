using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Security
{
    public static class Base64
    {
        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="str">内容</param>
        /// <param name="charset">编码方式</param>
        /// <returns></returns>
        public static string Compute(string str, string charset = "UTF-8")
        {
            return Convert.ToBase64String(Encoding.GetEncoding(charset).GetBytes(str));
        }
    }
}
