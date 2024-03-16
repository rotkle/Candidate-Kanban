using Kanban.Api.Models;

namespace Kanban.Api.Services.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusDto>> GetAllStatus();
    }
}