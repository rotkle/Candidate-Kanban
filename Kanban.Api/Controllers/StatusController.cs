using Kanban.Api.Models;
using Kanban.Api.Services;
using Kanban.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusService _statusService;

        public StatusController(ILogger<StatusController> logger, IStatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<IEnumerable<StatusDto>> GetAllStatus()
        {
            return await _statusService.GetAllStatus();
        }
    }
}