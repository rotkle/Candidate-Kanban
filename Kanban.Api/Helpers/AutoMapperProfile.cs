using AutoMapper;
using Kanban.Api.Entities;
using Kanban.Api.Models;

namespace Kanban.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Candidate -> CandidateDto
            CreateMap<Candidate, CandidateDto>()
                .ForMember(x => x.Jobs, options => options.Ignore());

            //Status -> StatusDto
            CreateMap<Status, StatusDto>();

            //Job -> JobDto
            CreateMap<Job, JobDto>();
        }
    }
}