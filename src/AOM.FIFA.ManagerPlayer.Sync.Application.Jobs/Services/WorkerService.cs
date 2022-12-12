using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services
{
    public class WorkerService : BackgroundService
    {
        private const int generalDelay = 1 * 10 * 1000;
        
        IServiceProvider _serviceProvider;
        public WorkerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {                
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _syncService = scope.ServiceProvider.GetService<ISyncJobService>();
                    await _syncService.ExecuteJobsAsync();
                }
                await Task.Delay(generalDelay, stoppingToken);
            }
        }        
    }
}
