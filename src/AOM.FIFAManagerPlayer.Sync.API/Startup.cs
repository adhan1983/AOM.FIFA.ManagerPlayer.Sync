using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Api.Extensions.Build;
using Hangfire;

namespace AOM.FIFAManagerPlayer.Jobs.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) => services.Build(Configuration);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) => app.Build(env);

    }
}
