using NSwag.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace AOM.FIFAManagerPlayer.Sync.API.Controllers
{
    [Route("api/sync")]
    [ApiController]
    [OpenApiTag("Sync FIFA", Description = "End point responsable for Synchronazation")]
    [Authorize]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService _syncService;
        private readonly ILogger<SyncController> _logger;

        public SyncController(ISyncService syncService, ILogger<SyncController> logger)
        {
            _syncService = syncService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogWarning("Calling GetSynchronizationsAsync");

                var response = await _syncService.GetSynchronizationsAsync();

                _logger.LogWarning("Calling GetSynchronizationsAsync");

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);               
                
            }
            
            return BadRequest();

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
