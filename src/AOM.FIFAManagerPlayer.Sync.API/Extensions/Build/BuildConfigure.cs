﻿using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.Build
{
    public static class BuildConfigure
    {
        //, IBackgroundJobClient backgroundJobs
        public static void Build(this IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AOM.FIFA.ManagerPlayer.Api v1"));
            }

            //app.UseHangfireDashboard();        

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseHangfireDashboard("/fifadashboard");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();               

            });

            app.ApplyMigration();
        }
    }
}
