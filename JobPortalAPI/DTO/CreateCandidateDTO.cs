using System;
using System.Collections.Generic;

namespace JobPortalAPI.DTO
{

    public class CreateCandidateDTO
    {
        public string Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int experience { get; set; }
        public List<int> skills { get; set; }



    }
}