using System;
using System.Collections.Generic;
using System.Text;

namespace Kdniao.Core
{
    /// <summary>
    /// 快递鸟 请求接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IKdniaoRequest<T> where T : KdniaoResponse
    {
        /// <summary>
        /// 获取快递鸟的异步通知地址。
        /// </summary>
        /// <returns>异步通知地址</returns>
        string GetNotifyUrl();

        /// <summary>
        /// 设置快递鸟的异步通知地址。
        /// </summary>
        /// <returns>异步通知地址</returns>
        void SetNotifyUrl(string notifyUrl);


    }
}
