using Kanban.Api.Models;

namespace Kanban.Api.Services.Interfaces
{
    /// <summary>
    /// Status service contain business functions related to Status
    /// </summary>
    public interface IStatusService
    {
        /// <summary>
        /// Get all Status
        /// </summary>
        /// <returns>List of all Status</returns>
        Task<IEnumerable<StatusDto>> GetAllStatus();
    }
}