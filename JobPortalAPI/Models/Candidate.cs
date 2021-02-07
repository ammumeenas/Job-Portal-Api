using System;
using System.Collections.Generic;

namespace JobPortalAPI.Models
{
    public class Candidate
    {
        public String Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Experience { get; set; }
        public List<CandidateSkill> CandidateSkills { get; set; }
        public List<CandidateJob> CandidateJobs { get; set; }


    }

}