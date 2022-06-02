using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AOM.FIFAManagerPlayer.Jobs.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var context = new ContextStrategy();

            //Console.WriteLine("Client: Strategy is set to normal sorting.");
            //context.SetStrategy(new ConcreteStrategyA());
            //context.DoSomeBusinessLogic();

            //Console.WriteLine();

            //Console.WriteLine("Client: Strategy is set to reverse sorting.");
            //context.SetStrategy(new ConcreteStrategyB());
            //context.DoSomeBusinessLogic();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
