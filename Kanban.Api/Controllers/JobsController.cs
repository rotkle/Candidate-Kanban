using Kanban.Api.Models;
using Kanban.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobsController> _logger;
        private readonly IJobService _jobService;

        public JobsController(ILogger<JobsController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IEnumerable<JobDto>> GetAllJobs()
        {
            return await _jobService.GetAllJobs();
        }
    }
}