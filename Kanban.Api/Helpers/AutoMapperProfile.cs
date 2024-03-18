using AutoMapper;
using Kanban.Api.Entities;
using Kanban.Api.Models;

namespace Kanban.Api.Helpers
{
    /// <summary>
    /// AutoMapper profile configuration. Please define mapping profiles in this file
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Candidate -> CandidateDto
            CreateMap<Candidate, CandidateDto>()
                .ForMember(x => x.Jobs, options => options.Ignore());

            //CandidateRequestDto -> Candidate
            CreateMap<CandidateRequestDto, Candidate>();

            //Status -> StatusDto
            CreateMap<Status, StatusDto>();

            //Job -> JobDto
            CreateMap<Job, JobDto>();
        }
    }
}