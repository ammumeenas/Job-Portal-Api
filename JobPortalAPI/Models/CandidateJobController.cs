using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateJobController : ControllerBase
    {
        private readonly JobDbContext _context;

        public CandidateJobController(JobDbContext context)
        {
            _context = context;
        }

        // GET: api/CandidateJob
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateJob>>> GetCandidateJobs()
        {
            return await _context.CandidateJobs.ToListAsync();
        }

        // GET: api/CandidateJob/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateJob>> GetCandidateJob(string id)
        {
            var candidateJob = await _context.CandidateJobs.FindAsync(id);

            if (candidateJob == null)
            {
                return NotFound();
            }

            return candidateJob;
        }

        // PUT: api/CandidateJob/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateJob(string id, CandidateJob candidateJob)
        {
            if (id != candidateJob.CandidateId)
            {
                return BadRequest();
            }

            _context.Entry(candidateJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateJobExists(id))
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

        // POST: api/CandidateJob
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CandidateJob>> PostCandidateJob(CandidateJob candidateJob)
        {
            _context.CandidateJobs.Add(candidateJob);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CandidateJobExists(candidateJob.CandidateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCandidateJob", new { id = candidateJob.CandidateId }, candidateJob);
        }

        // DELETE: api/CandidateJob/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateJob>> DeleteCandidateJob(string id)
        {
            var candidateJob = await _context.CandidateJobs.FindAsync(id);
            if (candidateJob == null)
            {
                return NotFound();
            }

            _context.CandidateJobs.Remove(candidateJob);
            await _context.SaveChangesAsync();

            return candidateJob;
        }

        private bool CandidateJobExists(string id)
        {
            return _context.CandidateJobs.Any(e => e.CandidateId == id);
        }
    }
}
