﻿using System;
using System.Collections.Generic;
using System.Linq;
using JobPortalAPI.DTO;
using JobPortalAPI.Models;

namespace JobPortalAPI.Common
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<Skill, SkillDTO>();

            CreateMap<Job, JobDTO>()
                .ForMember(dto => dto.Skills, c => c.MapFrom(job => job.JobSkills.Select(js => js.Skill)))
                .ForMember(dto => dto.Candidates, c => c.MapFrom(job =>job.CandidateJobs.Select(cs => cs.Candidate)));

            CreateMap<CreateJobDTO, Job>();

            CreateMap<CreateCandidateDTO, Candidate>();


            CreateMap<Candidate, CandidateDTO>()
             .ForMember(dto => dto.skills, c => c.MapFrom(candidate => candidate.CandidateSkills.Select(js => js.Skill)))
            .ForMember(dto => dto.jobs, c => c.MapFrom(candidate => candidate.CandidateJobs.Select(js => js.Job)));


            //CreateMap<Candidate, CandidateDTO>()
            // .ForMember(dto => dto.jobs, c => c.MapFrom(candidate => candidate.CandidateJobs.Select(js => js.Job)));
            //    .ForMember    (job => job.JobSkills, c => {

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
