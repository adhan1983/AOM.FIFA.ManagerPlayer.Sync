using Hangfire;
using NSwag.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using System;

namespace AOM.FIFAManagerPlayer.Sync.API.Controllers
{

    [Route("api/job")]
    [ApiController]
    [OpenApiTag("Job FIFA", Description = "")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public JobController(IJobService jobService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _jobService = jobService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        [HttpGet("/DelayedJob")]
        public ActionResult CreateDelayedJob(int seconds)
        {
            var result = _backgroundJobClient.Schedule(() => _jobService.ExecuteAllJosbsAsync(), TimeSpan.FromSeconds(seconds));

            return Ok(result);
        }

        
        //[HttpGet("/FireAndForgetJob")]
        //public ActionResult CreateFireAndForgetJob()
        //{
        //    _backgroundJobClient.Enqueue(() => _jobService.FireAndForgetJob());
            
        //    return Ok();
        //}       

        //[HttpGet("/ReccuringJob")]
        //public ActionResult CreateReccuringJob()
        //{
        //    _recurringJobManager.AddOrUpdate("jobId", () => _jobService.ReccuringJob(), Cron.Minutely);
        //    return Ok();
        //}

        //[HttpGet("/ContinuationJob")]
        //public ActionResult CreateContinuationJob()
        //{
        //    var parentJobId = _backgroundJobClient.Enqueue(() => _jobService.FireAndForgetJob());
        //    _backgroundJobClient.ContinueJobWith(parentJobId, () => _jobService.ContinuationJob());

        //    return Ok();
        //}
    }
}
