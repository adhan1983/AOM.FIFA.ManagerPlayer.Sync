//using AOM.FIFA.ManagerPlayer.Logging.Service;
//using NLog;
//using System.IO;
//using Microsoft.Extensions.DependencyInjection;
//using AOM.FIFA.ManagerPlayer.Logging.Interfaces;

//namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
//{
//    public static class LoggingServiceCollectionDependencies
//    {
//        public static void AddingLoggerServiceDependencies(this IServiceCollection services)
//        {
//            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//            services.AddSingleton<ILoggerManager, LoggerManager>();
//        }
//    }
//}
