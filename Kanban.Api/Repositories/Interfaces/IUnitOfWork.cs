namespace Kanban.Api.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        IStatusRepository Status { get; }
        IJobRepository Jobs { get; }
        int Save();
    }
}