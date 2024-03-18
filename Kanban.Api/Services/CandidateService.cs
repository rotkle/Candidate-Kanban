using AutoMapper;
using Kanban.Api.Entities;
using Kanban.Api.Helpers;
using Kanban.Api.Models;
using Kanban.Api.Repositories.Interfaces;
using Kanban.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Api.Services
{
    /// <summary>
    /// Implementation of <see cref="ICandidateService"/>
    /// </summary>
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CandidateService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public async Task Create(CandidateRequestDto data)
        {
            var candidate = await _unitOfWork.Candidates.Get(x => x.Email == data.Email).FirstOrDefaultAsync();
            if (candidate != null)
            {
                throw new AppException("Email is already exist! Please choice other email");
            }

            candidate = await _unitOfWork.Candidates.Get(x => x.PhoneNumber == data.PhoneNumber).FirstOrDefaultAsync();
            if (candidate != null)
            {
                throw new AppException("Phone number is already exist! Please choice other phone number");
            }

            candidate = _mapper.Map<Candidate>(data);

            // create candidate jobs
            if (data.JobIds != null)
            {
                candidate.CandidateJobs = data.JobIds.Select(x => new CandidateJob
                {
                    JobId = x
                }).ToList();
            }

            _unitOfWork.Candidates.Insert(candidate);
            _unitOfWork.Save();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CandidateDto>> GetAll()
        {
            var result = new List<CandidateDto>();
            var candidates = await _unitOfWork.Candidates.Get().Include(x => x.Status)
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

        /// <inheritdoc/>
        public async Task<CandidateDto> GetById(int id)
        {
            var candidate = await _unitOfWork.Candidates.Get().Include(x => x.Status)
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

        /// <inheritdoc/>
        public async Task Update(int id, CandidateRequestDto data)
        {
            var candidate = await _unitOfWork.Candidates.Get(x => x.Id == id)
                                                        .Include(x => x.CandidateJobs) 
                                                        .FirstOrDefaultAsync();
            if (candidate == null)
            {
                throw new KeyNotFoundException("Candidate not found");
            }

            var existCandidate = await _unitOfWork.Candidates.Get(x => x.Email == data.Email).FirstOrDefaultAsync();
            if (existCandidate != null && existCandidate != candidate)
            {
                throw new AppException("Email is already exist! Please choice other email");
            }

            existCandidate = await _unitOfWork.Candidates.Get(x => x.PhoneNumber == data.PhoneNumber).FirstOrDefaultAsync();
            if (existCandidate != null && existCandidate != candidate)
            {
                throw new AppException("Phone number is already exist! Please choice other phone number");
            }
            // update candidate data
            candidate.Email = data.Email;
            candidate.PhoneNumber = data.PhoneNumber;
            candidate.FirstName = data.FirstName;
            candidate.LastName = data.LastName;
            candidate.StatusId = data.StatusId;

            // update jobs
            if (data.JobIds != null)
            {
                candidate.CandidateJobs = data.JobIds.Select(x => new CandidateJob
                {
                    CandidateId = id,
                    JobId = x
                }).ToList();
            }

            _unitOfWork.Candidates.Update(candidate);
            _unitOfWork.Save();
        }
    }
}