using Kanban.Api.Entities;
using Kanban.Api.Helpers;
using Kanban.Api.Repositories.Interfaces;

namespace Kanban.Api.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IJobRepository"/>. Also inherit from <see cref="GenericRepository{T}"/>
    /// </summary>
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(DataContext context) : base(context)
        {
        }
    }
}