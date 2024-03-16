using Kanban.Api.Helpers;
using Kanban.Api.Repositories.Interfaces;

namespace Kanban.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public ICandidateRepository Candidates { get; }

        public UnitOfWork(DataContext context, ICandidateRepository Candidates)
        {
            this._context = context;
            this.Candidates = Candidates;
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