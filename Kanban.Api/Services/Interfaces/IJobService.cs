using Kanban.Api.Models;

namespace Kanban.Api.Services.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<JobDto>> GetAllJobs();
    }
}