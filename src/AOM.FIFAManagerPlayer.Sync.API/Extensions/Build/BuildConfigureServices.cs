using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFAManagerPlayer.Sync.API.Extensions;
using AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies;
using AOM.FIFAManagerPlayer.Sync.API.Extensions.ServicesCollectionDependencies;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.Build
{
    public static class BuildConfigureServices
    {
        public static void Build(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AOM.FIFA.ManagerPlayer.Sync", Version = "v1" });
            });

            services.
                AddingApplicationDependencies().
                AddingApplicationJobsDependencies().
                AddingPersistenceDependencies().
                AddingApplicationgRPCClientDependencies().
                AddingAutoMapperDependencies().
                AddingHttpClientFactory(configuration).
                AddingGrpcDependencies(configuration).
                AddingAuth0Dependencies(configuration).
                AddingDataBasesDependencies(configuration);
                
                
        }

    }
}
