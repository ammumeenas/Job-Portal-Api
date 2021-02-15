using System;
using System.Collections.Generic;

namespace JobPortalAPI.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<JobSkill> jobSkills { get; set; }

    }
}
