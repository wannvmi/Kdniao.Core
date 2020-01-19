using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kdniao.Core
{
    public interface IKdniaoNotifyClient
    {
        Task<T> ExecuteAsync<T>(HttpRequest request) where T : KdniaoNotify;
        Task<T> ExecuteAsync<T>(HttpRequest request, KdniaoOptions options) where T : KdniaoNotify;
        IActionResult Success(DateTime? updateTime = null);
        IActionResult Success(KdniaoOptions options, DateTime? updateTime = null);
        IActionResult Error(string reason = "", DateTime? updateTime = null);
        IActionResult Error(KdniaoOptions options, string reason = "", DateTime? updateTime = null);
    }
}
