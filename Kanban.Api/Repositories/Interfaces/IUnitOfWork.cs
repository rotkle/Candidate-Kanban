namespace Kanban.Api.Repositories.Interfaces
{
    /// <summary>
    /// UnitOfWork contain all repositories to make sure every changes from every entities is save as one transaction per request.
    /// Transaction will success save if no change fail, else no thing will be save to full fill database data correctness
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        IStatusRepository Status { get; }
        IJobRepository Jobs { get; }
        int Save();
    }
}