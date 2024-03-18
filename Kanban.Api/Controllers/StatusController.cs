using Kanban.Api.Models;
using Kanban.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    /// <summary>
    /// API related to Status resource
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusService _statusService;

        /// <summary>
        /// Initialize an instance of <see cref="StatusController"/>
        /// </summary>
        /// <param name="logger">An instance of <see cref="ILogger"/></param>
        /// <param name="statusService">An instance of <see cref="IStatusService"/></param>
        public StatusController(ILogger<StatusController> logger, IStatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        /// <summary>
        /// API for get all Status
        /// </summary>
        /// <returns>List of Status</returns>
        [HttpGet]
        public async Task<IEnumerable<StatusDto>> GetAllStatus()
        {
            return await _statusService.GetAllStatus();
        }
    }
}