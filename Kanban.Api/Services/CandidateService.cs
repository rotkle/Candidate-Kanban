using AutoMapper;
using Kanban.Api.Entities;
using Kanban.Api.Helpers;
using Kanban.Api.Models;
using Kanban.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Api.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CandidateService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateDto>> GetAll()
        {
            var result = new List<CandidateDto>();
            var candidates = await _context.Candidates.Include(x => x.Status)
                                                      .Include(x => x.CandidateJobs)
                                                      .ThenInclude(x => x.Job)
                                                      .ToListAsync();

            if (candidates == null || !candidates.Any())
            {
                return result;
            }

            foreach (var candidate in candidates)
            {
                var model = _mapper.Map<CandidateDto>(candidate);
                model.Jobs = _mapper.Map<List<JobDto>>(candidate.CandidateJobs.Select(x => x.Job));
                result.Add(model);
            }

            return result;
        }

        public async Task<CandidateDto> GetById(int id)
        {
            var candidate = await _context.Candidates.Include(x => x.Status)
                                                     .Include(x => x.CandidateJobs)
                                                     .ThenInclude(x => x.Job)    
                                                     .Where(x => x.Id == id)
                                                     .FirstOrDefaultAsync();

            if (candidate == null)
                throw new KeyNotFoundException("Candidate not found");

            var result = _mapper.Map<CandidateDto>(candidate);
            result.Jobs = _mapper.Map<List<JobDto>>(candidate.CandidateJobs.Select(x => x.Job));

            return result;
        }
    }
}