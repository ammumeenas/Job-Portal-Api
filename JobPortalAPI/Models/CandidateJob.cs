using System;
namespace JobPortalAPI.Models
{
    public class CandidateJob
    {
        public Candidate Candidate { get; set; }
        public string CandidateId { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }


    }
}
