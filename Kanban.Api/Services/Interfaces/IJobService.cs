using Kanban.Api.Models;

namespace Kanban.Api.Services.Interfaces
{
    /// <summary>
    /// Job service contain business functions related to Job
    /// </summary>
    public interface IJobService
    {
        /// <summary>
        /// Get all Jobs
        /// </summary>
        /// <returns>List of all Jobs</returns>
        Task<IEnumerable<JobDto>> GetAllJobs();
    }
}