using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class JobController : ControllerBase
    {
        private readonly JobDbContext _context;
        private readonly IMapper _mapper;


        public JobController(JobDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        // GET: api/Job
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs()
        {

            List<Job> Jobs= await _context.Jobs
                 .Include(job => job.JobSkills).ThenInclude(jobskill => jobskill.Skill)
                 .Include(job => job.CandidateJobs).ThenInclude(candidatejobs => candidatejobs.Job)
            .ToListAsync();
            List<JobDTO> JobDTOs = _mapper.Map<List<JobDTO>>(Jobs);

            return JobDTOs;
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDTO>> GetJob(int id)
        {
            var job = await _context.Jobs
        .Include(job => job.JobSkills).ThenInclude(jobskill => jobskill.Skill)
                 .Include(job => job.CandidateJobs).ThenInclude(candidatejobs => candidatejobs.Job)
        .FirstOrDefaultAsync(job => job.id == id);
            JobDTO jobDTO = _mapper.Map<JobDTO>(job);
        

            if (job == null)
            {
                return NotFound();
            }

            return jobDTO;
        }

        // PUT: api/Job/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutJob(int id, CreateJobDTO jobDTO)
        {
            Job job = _mapper.Map<Job>(jobDTO);



            if (id != jobDTO.id)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;
            _context.SaveChanges();

            

            try
            {
                JobSkill js = new JobSkill { JobId = jobDTO.id };
                _context.JobSkill.RemoveRange(_context.JobSkill.Where(js => js.JobId == jobDTO.id));
                _context.SaveChanges();
          

                foreach (var skillId in jobDTO.Skills)
                {
                    JobSkill jobskill = new JobSkill
                    {
                        JobId = jobDTO.id,
                        SkillId = skillId
                    };
                    _context.JobSkill.Add(jobskill);

                }
                _context.SaveChanges();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //POST: api/Job
        //To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<CreateJobDTO> PostJob(CreateJobDTO jobDTO)
        {
            Job job = _mapper.Map<Job>(jobDTO);
            _context.Jobs.Add(job);

            _context.SaveChanges();


            foreach (var skill in jobDTO.Skills)
            {
                JobSkill jobSkill = new JobSkill
                {
                    JobId = job.id,
                    SkillId = skill
                };
                _context.JobSkill.Add(jobSkill);

            }
            _context.SaveChanges();


            return CreatedAtAction("GetJob", new { id = job.id }, job);

        }

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> DeleteJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return job;
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.id == id);
        }
    }
}
