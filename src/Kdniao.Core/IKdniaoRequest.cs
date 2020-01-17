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
        /// 获取快递鸟的沙箱异步通知地址。
        /// </summary>
        /// <returns></returns>
        string GetSandBoxNotifyUrl();

        /// <summary>
        /// 设置快递鸟的异步通知地址。
        /// </summary>
        /// <returns>异步通知地址</returns>
        void SetNotifyUrl(string notifyUrl);

        /// <summary>
        /// 获取请求内容
        /// </summary>
        /// <returns></returns>
        string GetRequestData();

        /// <summary>
        /// 获取所有的Key-Value形式的文本请求参数字典。其中：
        /// Key: 请求参数名
        /// Value: 请求参数文本值
        /// </summary>
        /// <returns>文本请求参数字典</returns>
        IDictionary<string, string> GetParameters();

    }
}
