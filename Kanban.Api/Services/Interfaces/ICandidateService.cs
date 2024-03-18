using Kanban.Api.Entities;
using Kanban.Api.Models;

namespace Kanban.Api.Services.Interfaces
{
    /// <summary>
    /// Candidate service contain business functions related to Candidate
    /// </summary>
    public interface ICandidateService
    {
        /// <summary>
        /// Get all Candidates
        /// </summary>
        /// <returns>List of all Candidates in database</returns>
        Task<IEnumerable<CandidateDto>> GetAll();

        /// <summary>
        /// Get specific Candidate by Id
        /// </summary>
        /// <param name="id">Candidate's Id</param>
        /// <returns>A specific Candidate</returns>
        Task<CandidateDto> GetById(int id);

        /// <summary>
        /// Create new Candidate
        /// </summary>
        /// <param name="data">Create Candidate data</param>
        /// <returns>Async task</returns>
        Task Create(CandidateRequestDto data);

        /// <summary>
        /// Update Candidate
        /// </summary>
        /// <param name="id">Id of Candidate to be updated</param>
        /// <param name="data">Update Candidate data</param>
        /// <returns>Async task</returns>
        Task Update(int id, CandidateRequestDto data);
    }
}