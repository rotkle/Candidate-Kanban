using Kanban.Api.Entities;

namespace Kanban.Api.Repositories.Interfaces
{
    /// <summary>
    /// Specific repository contain custom functions to interact with Job data
    /// </summary>
    public interface IJobRepository : IGenericRepository<Job>
    {
    }
}