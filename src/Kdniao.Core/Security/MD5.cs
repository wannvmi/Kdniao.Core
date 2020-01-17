using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core.Security
{
    public static class MD5
    {
        ///<summary>
        /// 字符串MD5加密
        ///</summary>
        ///<param name="str">要加密的字符串</param>
        ///<param name="charset">编码方式</param>
        ///<returns>密文</returns>
        public static string Compute(string str, string charset = "UTF-8")
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var hsah = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(str));
                return BitConverter.ToString(hsah).Replace("-", "");
            }
        }
    }
}
