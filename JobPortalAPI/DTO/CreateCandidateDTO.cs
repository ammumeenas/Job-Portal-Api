using System;
using System.Collections.Generic;

namespace JobPortalAPI.DTO
{

    public class CreateCandidateDTO
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Experience { get; set; }
        public List<int> Skills { get; set; }



    }
}