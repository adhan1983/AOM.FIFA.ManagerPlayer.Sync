using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace AOM.FIFAManagerPlayer.Sync.API.Controllers
{
    [Route("api/job")]
    [ApiController]
    [OpenApiTag("Sync FIFA", Description = "End point responsable for Synchronazation")]
    public class jobController : ControllerBase
    {
        private readonly ISyncJobService _syncService;

        public jobController(ISyncJobService syncService) => this._syncService = syncService;

        [HttpGet]        
        public async Task<IActionResult> Get()
        {
            await _syncService.ExecuteJobsAsync();

            //for (int i = 0; i < 300; i++)
            //{
            //    await _syncService.ExecuteJobsAsync();
            //    Thread.Sleep(3000);
            //}

            return Ok("Ok");

        }        
    }
}
