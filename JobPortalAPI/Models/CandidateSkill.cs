using System;
namespace JobPortalAPI.Models
{
    public class CandidateSkill
    {
        public Candidate Candidate { get; set; }
        public string CandidateId { get; set; }
        public Skill Skill { get; set; }
        public int SkillId { get; set; }

    }
}
