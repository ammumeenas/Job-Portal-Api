using System;
using System.Collections.Generic;
using JobPortalAPI.Models;

namespace JobPortalAPI.DTO
{
    public class CandidateDTO
    {

        public String Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int experience { get; set; }
        public List<Skill> skills { get; set; }
    }
}