using System;
using Hangfire;
using NSwag.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AOM.FIFA.ManagerPlayer.Sync.Application.Base.Contants;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;

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

        public JobController(IJobService jobService, IBackgroundJobClient backgroundJobClient)
        {
            _jobService = jobService;
            _backgroundJobClient = backgroundJobClient;            
        }

        [HttpGet("/ScheduleJobFromSeconds")]
        public ActionResult ScheduleJobFromSeconds(int seconds)
        {
            var result = _backgroundJobClient.Schedule(() => _jobService.ExecuteAllJosbsAsync(), TimeSpan.FromSeconds(seconds));

            return Ok(result);
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
