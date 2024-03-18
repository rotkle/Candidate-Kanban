using Kanban.Api.Entities;
using Kanban.Api.Helpers;
using Kanban.Api.Repositories.Interfaces;

namespace Kanban.Api.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IStatusRepository"/>. Also inherit from <see cref="GenericRepository{T}"/>
    /// </summary>
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(DataContext context) : base(context)
        {
        }
    }
}