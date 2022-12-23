using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions
{
    public static class SyncManager
    {
        public static async void BuildSyncManager(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IJobService>();

                await service.SyncPageAsync();                
            }
        }
    }
}
