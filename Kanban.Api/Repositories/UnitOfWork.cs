using Kanban.Api.Helpers;
using Kanban.Api.Repositories.Interfaces;

namespace Kanban.Api.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IUnitOfWork"/>
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public ICandidateRepository Candidates { get; }

        public IStatusRepository Status { get; }

        public IJobRepository Jobs { get; }

        public UnitOfWork(DataContext context, ICandidateRepository Candidates, IStatusRepository Status, IJobRepository Jobs)
        {
            this._context = context;
            this.Candidates = Candidates;
            this.Status = Status;
            this.Jobs = Jobs;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}