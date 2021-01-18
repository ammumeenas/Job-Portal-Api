using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalAPI.Models;
using AutoMapper;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> PutJob(int id, Job job)
        {
            if (id != job.id)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        // POST: api/Job
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

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
