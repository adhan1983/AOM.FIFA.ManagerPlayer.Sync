using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

namespace AOM.FIFAManagerPlayer.Jobs.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration((context, config) => {

                        var buildCofiguration = config.Build();
                        string kvURL = buildCofiguration["FIFAMANAGERPLAYERSYNCKV:kvURL"];
                        string tenantId = buildCofiguration["FIFAMANAGERPLAYERSYNCKV:TenantId"];
                        string clientId = buildCofiguration["FIFAMANAGERPLAYERSYNCKV:ClientId"];
                        string clientSecret = buildCofiguration["FIFAMANAGERPLAYERSYNCKV:ClientSecret"];

                        var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
                        var client = new SecretClient(new System.Uri(kvURL), credentials);
                        config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());


                    });

                });
    }
}
