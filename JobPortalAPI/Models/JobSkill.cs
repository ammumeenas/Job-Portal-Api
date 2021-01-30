using System;
namespace JobPortalAPI.Models
{
    public class JobSkill
    {
        public JobSkill(int _SkillId) {
            SkillId = _SkillId;
        }
        public Job Job { get; set; }
        public int JobId { get; set; }
        public Skill Skill { get; set; }
        public int SkillId {get; set; }


    }
}
