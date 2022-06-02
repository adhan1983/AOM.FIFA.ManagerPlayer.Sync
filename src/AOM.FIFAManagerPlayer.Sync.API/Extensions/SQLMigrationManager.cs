using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Context;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class SQLMigrationManager
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();                
                bool applyMigrationSyncFIFADbContext = config.GetSection(ApiConstants.ApplyMigrationSyncFIFADbContext).Get<bool>();
                
                if (applyMigrationSyncFIFADbContext) 
                {
                    var fifaSyncDbContext = scope.ServiceProvider.GetService<FIFASyncDbContext>();
                    fifaSyncDbContext.Database.Migrate();
                }

                //var _syncService = scope.ServiceProvider.GetService<Sync.Application.Jobs.Interfaces.ISyncJobService>();
                //RecurringJob.AddOrUpdate(
                //"FifaJob",
                //() => _syncService.ExecuteJobsAsync(),
                //Cron.Minutely);

            }
        }

    }

}
