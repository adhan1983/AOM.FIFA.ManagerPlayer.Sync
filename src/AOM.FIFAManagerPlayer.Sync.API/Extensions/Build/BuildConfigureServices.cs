using Microsoft.OpenApi.Models;
using System.Collections.Generic;
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

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "AOM.FIFA.ManagerPlayer.Sync.Api", Version = "v1" });

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                var lst = new List<string>();
                lst.Add("Bearer");

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        lst
                    }
                });

            });

            services.AddingAuthenticationDependencies(configuration);            

            services.AddMemoryCache();
            
            services.
                AddingApplicationDependencies().
                AddingApplicationJobsDependencies().
                AddingPersistenceDependencies().
                AddingApplicationgRPCClientDependencies().
                AddingAutoMapperDependencies().                
                AddingHttpClientFactory(configuration).
                AddingGrpcDependencies(configuration).
                AddingAuth0Dependencies(configuration).
                AddingDataBasesDependencies(configuration).
                AddingHangiFideDependencies(configuration);               
                
        }

    }
}
