using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Reponses;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace AOM.FIFAManagerPlayer.Sync.API.Controllers
{
    [Route("api/sync")]
    [ApiController]
    [OpenApiTag("Sync FIFA", Description = "End point responsable for Synchronazation")]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService _syncService;

        public SyncController(ISyncService syncService) => this._syncService = syncService;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var response = new SyncListResponse();

            response = await _syncService.GetSynchronizationsAsync();

            return Ok(response);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new SyncResponse();

            response = await _syncService.GetSynchronizationsByIdAsync(id);

            return Ok(response);

        }
    }
}
