using System.Threading.Tasks;

namespace Kdniao.Core
{
    public interface IKdniaoClient
    {
        Task<T> ExecuteAsync<T>(IKdniaoRequest<T> request, KdniaoOptions options) where T : KdniaoResponse;
    }
}
