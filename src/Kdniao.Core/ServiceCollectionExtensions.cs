using System;
using Microsoft.Extensions.DependencyInjection;

namespace Kdniao.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddKdniao(
            this IServiceCollection services)
        {
            services.AddKdniao(null);
        }

        public static void AddKdniao(
            this IServiceCollection services,
            Action<KdniaoOptions> setupAction)
        {
            services.AddHttpClient(nameof(KdniaoClient));

            services.AddSingleton<IKdniaoClient, KdniaoClient>();
            services.AddSingleton<IKdniaoNotifyClient, KdniaoNotifyClient>();

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }
            else
            {
                services.Configure<KdniaoOptions>(options =>
                {
                    options.EBusinessID = string.Empty;
                    options.AppKey = string.Empty;
                });
            }
        }
    }
}
