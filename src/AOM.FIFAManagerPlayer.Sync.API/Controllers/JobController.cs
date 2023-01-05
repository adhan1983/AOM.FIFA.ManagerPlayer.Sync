using System;
using Hangfire;
using NSwag.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using Microsoft.Extensions.Logging;

namespace AOM.FIFAManagerPlayer.Sync.API.Controllers
{

    [Route("api/job")]
    [ApiController]
    [OpenApiTag("Job FIFA", Description = "")]
    [Authorize]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly ILogger<JobController> _logger;

        public JobController(IJobService jobService, IBackgroundJobClient backgroundJobClient, ILogger<JobController> logger)
        {
            _jobService = jobService;
            _backgroundJobClient = backgroundJobClient;
            _logger = logger;
        }

        //[HttpGet("/ScheduleJobFromSeconds")]
        //public ActionResult ScheduleJobFromSeconds(int seconds)
        //{
        //    var result = _backgroundJobClient.Schedule(() => _jobService.ExecuteAllJosbsAsync(), TimeSpan.FromSeconds(seconds));

        //    return Ok(result);
        //}

        [HttpGet("/ScheduleJobByNameAsync")]
        public ActionResult ScheduleJobLeagueAsync(string jobName, int seconds)
        {
            try
            {
                _logger.LogWarning("Calling Schedule");
                
                var result = _backgroundJobClient.Schedule(() => _jobService.ExecuteJobByNameAsync(jobName), TimeSpan.FromSeconds(seconds));

                _logger.LogWarning("end Schedule");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                
            }
            return BadRequest();
        }

       

        //[HttpGet("/ContinuationJob")]
        //public ActionResult ContinuationJob()
        //{
        //    var leagueJob = _backgroundJobClient.Enqueue(() =>  _jobService.ExecuteJobByNameAsync(ApplicationContants.League));

        //    var continueWithNationJob = _backgroundJobClient.ContinueJobWith(leagueJob, () => _jobService.ExecuteJobByNameAsync(ApplicationContants.Nation));

        //    var continueWithClubJob = _backgroundJobClient.ContinueJobWith(continueWithNationJob, () => _jobService.ExecuteJobByNameAsync(ApplicationContants.Club));

        //    _backgroundJobClient.ContinueJobWith(continueWithClubJob, () => _jobService.ExecuteJobByNameAsync(ApplicationContants.Player));

        //    return Ok(leagueJob);
        //}

    }
}
