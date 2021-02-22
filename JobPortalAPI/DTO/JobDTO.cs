using System;
using System.Collections.Generic;
using JobPortalAPI.DTO;

namespace JobPortalAPI.Models
{
    public class JobDTO
    {
        public int id { get; set; }
        public string role { get; set; }
        public int noOfOpenings { get; set; }
        public List<SkillDTO> Skills { get; set; }
        public string jobLocation { get; set; }
        public int yearsOfExperience { get; set; }
        public int noOfApplicants { get; set; }
        public bool isActive { get; set; }
        public string company { get; set; }
        public List<Candidate> Candidates { get; set; }


    }
}
