using System;
using System.Linq;
using JobPortalAPI.Models;

namespace JobPortalAPI.Common
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<Skill, SkillDTO>();
            CreateMap<Job, JobDTO>()
    .ForMember(dto => dto.Skills, c => c.MapFrom(c => c.JobSkills.Select(cs => cs.Skill)));
        }
    }
}
