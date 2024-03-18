using AutoMapper;
using Kanban.Api.Models;
using Kanban.Api.Repositories.Interfaces;
using Kanban.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Api.Services
{
    /// <summary>
    /// Implementation of <see cref="IJobService"/>
    /// </summary>
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<JobDto>> GetAllJobs()
        {
            var jobs = await _unitOfWork.Jobs.Get().ToListAsync();
            return _mapper.Map<List<JobDto>>(jobs);
        }
    }
}