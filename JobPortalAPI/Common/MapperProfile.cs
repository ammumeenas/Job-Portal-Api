using System;
using System.Collections.Generic;
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
                .ForMember(dto => dto.Skills, c => c.MapFrom(job => job.JobSkills.Select(js => js.Skill)));

            //CreateMap<CreateJobDTO, Job>()
            //    .ForMember(job => job.JobSkills, c => {

            //        List<JobSkill> jsList = new List<JobSkill>();
            //        c.MapFrom(createJOBDTO => createJOBDTO.Skills.Select(id => {

            //            JobSkill js = new JobSkill(id);
            //            js.SkillId = id;
            //            //jsList.Add(js);

            //        });

            //    }) ;
        }
    }
}
