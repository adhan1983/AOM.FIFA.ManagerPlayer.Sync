using System;
using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Gateway.Utils;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class HttpClientFactoryServiceExtension
    {
        public static IServiceCollection AddingHttpClientFactory(this IServiceCollection services, IConfiguration configuration) 
        {            
            services.AddHttpClient(configuration.GetValue<string>(ApiConstants.FIFAClient), config => 
            {
                config.BaseAddress = new Uri(configuration.GetValue<string>(ApiConstants.BaseAddress));
                config.Timeout = new TimeSpan(0, 0, 30);
                config.DefaultRequestHeaders.Clear();
            });

            services.AddSingleton<IFIFAGatewayConfig, FIFAGatewayConfig>(scope =>
            {
                FIFAGatewayConfig gatewayConfig = new FIFAGatewayConfig();

                gatewayConfig.FIFAApiKey = configuration.GetValue<string>(ApiConstants.FIFAApiKey);
                gatewayConfig.FIFAApiToken = configuration.GetValue<string>(ApiConstants.FIFAApiToken);
                gatewayConfig.FIFAClient = configuration.GetValue<string>(ApiConstants.FIFAClient);

                return gatewayConfig;
            });


            services.AddSingleton<IFIFAManager, FIFAManager>(scope =>
            {
                FIFAManager fifaManager = new FIFAManager();

                fifaManager.BaseAddress = configuration.GetValue<string>(ApiConstants.FIFAManagerBaseAddress);
                fifaManager.League = configuration.GetValue<string>(ApiConstants.FIFAManagerLeague);
                fifaManager.Player = configuration.GetValue<string>(ApiConstants.FIFAManagerPlayer);
                fifaManager.Club = configuration.GetValue<string>(ApiConstants.FIFAManagerClub);
                fifaManager.Nation = configuration.GetValue<string>(ApiConstants.FIFAManagerNation);

                return fifaManager;
            });

            services.AddSingleton<IFIFAUrl, FIFAUrl>(scope => 
            {
                FIFAUrl urls = new FIFAUrl();
                
                urls.club = configuration.GetValue<string>(ApiConstants.Club);
                urls.league = configuration.GetValue<string>(ApiConstants.League);                
                urls.nation = configuration.GetValue<string>(ApiConstants.Nation);
                urls.player = configuration.GetValue<string>(ApiConstants.Player);

                return urls;
            });

            services.AddSingleton<IFIFAUrlQueryString, FIFAUrlQueryString>(scope => 
            {
                FIFAUrlQueryString queryString = new FIFAUrlQueryString();

                queryString.Page = configuration.GetValue<string>(ApiConstants.Page);
                queryString.Limit = configuration.GetValue<string>(ApiConstants.Limit);

                return queryString;
            });

            services.AddScoped<IHttpClientFactoryService, HttpClientFactoryService>();

            return services;
        }
    }
}
