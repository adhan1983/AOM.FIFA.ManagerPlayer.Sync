using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions
{
    public static class ManagerDistributedCache
    {
        public static async void AddingCacheDependencies(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
               var service = scope.ServiceProvider.GetService<IDistributeGRPCServiceCache>();

                await service.GetAccessToken();
            }
        }
    }
}
