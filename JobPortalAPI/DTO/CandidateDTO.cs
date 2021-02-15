using System;
using System.Collections.Generic;
using JobPortalAPI.Models;

namespace JobPortalAPI.DTO
{
    public class CandidateDTO
    {

        public String Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Experience { get; set; }
        public List<Skill> Skills { get; set; }
    }
}