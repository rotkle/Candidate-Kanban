using AutoMapper;
using Kanban.Api.Models;
using Kanban.Api.Repositories.Interfaces;
using Kanban.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Api.Services
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StatusDto>> GetAllStatus()
        {
            var status = await _unitOfWork.Status.Get().ToListAsync();
            return _mapper.Map<List<StatusDto>>(status);
        }
    }
}