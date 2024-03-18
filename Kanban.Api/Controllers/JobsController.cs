using Kanban.Api.Models;
using Kanban.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    /// <summary>
    /// API related to Job resource
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobsController> _logger;
        private readonly IJobService _jobService;

        /// <summary>
        /// Initialize an instance of <see cref="JobsController"/>
        /// </summary>
        /// <param name="logger">An instance of <see cref="ILogger"/></param>
        /// <param name="jobService">An instance of <see cref="IJobService"/></param>
        public JobsController(ILogger<JobsController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        /// <summary>
        /// API for get all Jobs
        /// </summary>
        /// <returns>List of Jobs</returns>
        [HttpGet]
        public async Task<IEnumerable<JobDto>> GetAllJobs()
        {
            return await _jobService.GetAllJobs();
        }
    }
}