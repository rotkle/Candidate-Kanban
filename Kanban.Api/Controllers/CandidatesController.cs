using Kanban.Api.Entities;
using Kanban.Api.Models;
using Kanban.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ILogger<CandidatesController> _logger;
        private readonly ICandidateService _candidateService;

        public CandidatesController(ILogger<CandidatesController> logger, ICandidateService candidateService)
        {
            _logger = logger;
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IEnumerable<CandidateDto>> GetAllCandidates()
        {
            return await _candidateService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CandidateDto> GetCandidate(int id) 
        {
            return await _candidateService.GetById(id);
        }
    }
}