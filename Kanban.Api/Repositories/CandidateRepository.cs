using Kanban.Api.Entities;
using Kanban.Api.Helpers;
using Kanban.Api.Repositories.Interfaces;

namespace Kanban.Api.Repositories
{
    /// <summary>
    /// Implementation of <see cref="ICandidateRepository"/>. Also inherit from <see cref="GenericRepository{T}"/>
    /// </summary>
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(DataContext context) : base(context)
        {
        }
    }
}