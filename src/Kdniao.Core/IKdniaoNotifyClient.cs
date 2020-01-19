using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kdniao.Core
{
    public interface IKdniaoNotifyClient
    {
        Task<T> ExecuteAsync<T>(HttpRequest request) where T : KdniaoNotify;
        Task<T> ExecuteAsync<T>(HttpRequest request, KdniaoOptions options) where T : KdniaoNotify;
    }
}
