using Hangfire;
using Hangfire.Dashboard;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using AOM.FIFAManagerPlayer.Sync.API.Extensions;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.Build
{
    public static class BuildConfigure
    {        
        public static void Build(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AOM.FIFA.ManagerPlayer.Sync.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();            

            app.UseEndpoints(endpoints => 
            { 
                endpoints.MapControllers();                
            });            

            app.ApplyMigration();

            app.BuildSyncManager();

            app.AddingCacheDependencies();

            var scope = app.ApplicationServices.CreateScope();
            
            var service = scope.ServiceProvider.GetService<IHttpClientFactoryService>();

            app.UseHangfireDashboard("/hangfire",
                new DashboardOptions { Authorization = new[] { new HangfireDashboardJwtAuthorizationFilter(service) } });

        }
    }
}
