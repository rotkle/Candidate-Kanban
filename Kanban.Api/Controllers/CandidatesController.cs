using Kanban.Api.Models;
using Kanban.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    /// <summary>
    /// API related to Candidate resource
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ILogger<CandidatesController> _logger;
        private readonly ICandidateService _candidateService;

        /// <summary>
        /// Initialize an instance of <see cref="CandidatesController"/>
        /// </summary>
        /// <param name="logger">An instance of <see cref="ILogger"/></param>
        /// <param name="candidateService">An instance of <see cref="ICandidateService"/></param>
        public CandidatesController(ILogger<CandidatesController> logger, ICandidateService candidateService)
        {
            _logger = logger;
            _candidateService = candidateService;
        }

        /// <summary>
        /// API for get all Candidates
        /// </summary>
        /// <returns>List of Candidates</returns>
        [HttpGet]
        public async Task<IEnumerable<CandidateDto>> GetAllCandidates()
        {
            return await _candidateService.GetAll();
        }

        /// <summary>
        /// API for get specific Candidate by Id
        /// </summary>
        /// <param name="id">The Id of Candidate</param>
        /// <returns>A specific Candidate</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<CandidateDto> GetCandidate(int id) 
        {
            return await _candidateService.GetById(id);
        }

        /// <summary>
        /// API for create new Candidate
        /// </summary>
        /// <param name="data">Data of new Candidate</param>
        /// <returns>Create Candidate success</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody] CandidateRequestDto data)
        {
            await _candidateService.Create(data);
            return Ok();
        }

        /// <summary>
        /// API for update Candidate
        /// </summary>
        /// <param name="id">Id of the Candidate</param>
        /// <param name="data">Data need to be updated</param>
        /// <returns>Update Candidate success</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, [FromBody] CandidateRequestDto data)
        {
            await _candidateService.Update(id, data);
            return Ok();
        }
    }
}