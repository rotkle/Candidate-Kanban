using Kanban.Api.Entities;
using Kanban.Api.Models;

namespace Kanban.Api.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateDto>> GetAll();
        Task<CandidateDto> GetById(int id);
        //void Create(CreateRequest model);
    }
}