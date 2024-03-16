namespace Kanban.Api.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        int Save();
    }
}