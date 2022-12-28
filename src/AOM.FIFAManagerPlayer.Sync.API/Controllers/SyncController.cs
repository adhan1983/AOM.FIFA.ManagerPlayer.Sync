using NSwag.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Services;

namespace AOM.FIFAManagerPlayer.Sync.API.Controllers
{
    [Route("api/sync")]
    [ApiController]
    [OpenApiTag("Sync FIFA", Description = "End point responsable for Synchronazation")]
    [Authorize]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService _syncService;

        public SyncController(ISyncService syncService) => this._syncService = syncService;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var response = await _syncService.GetSynchronizationsAsync();

            return Ok(response);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _syncService.GetSynchronizationsByIdAsync(id);

            return Ok(response);

        }
    }
}
