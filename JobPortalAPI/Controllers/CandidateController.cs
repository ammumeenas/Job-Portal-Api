using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalAPI.Models;
using AutoMapper;
using JobPortalAPI.DTO;
using System.Security.Claims;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly JobDbContext _context;
        private readonly IMapper _mapper;

        public CandidateController(JobDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
            
        }

        // GET: api/Candidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDTO>>> GetCandidateProfiles()
        {
            List<Candidate> candidates = await _context.Candidates
          .Include(candidate => candidate.CandidateSkills).ThenInclude(CandidateSkill => CandidateSkill.Skill).ToListAsync();
            List<CandidateDTO> candidateDTOs = _mapper.Map<List<CandidateDTO>>(candidates);
            return candidateDTOs;
        }

        // GET: api/Candidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDTO>> GetCandidate(string id)
        {
            var candidate = await _context.Candidates
                .Include(candidate => candidate.CandidateSkills).ThenInclude(candidateskill => candidateskill.Skill)
                .FirstOrDefaultAsync(candidate => candidate.Id == id);
            CandidateDTO candidateDTO = _mapper.Map<CandidateDTO>(candidate);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidateDTO;
        }

        // PUT: api/Candidate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCandidate(string id, CandidateDTO candidateDTO)
        {
            Candidate candidate = _mapper.Map<Candidate>(candidateDTO);
            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            if (id != candidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {

                foreach (var CandidateSkill in candidate.CandidateSkills)
                {
                    CandidateSkill candidateskill = new CandidateSkill
                    {
                        CandidateId = candidate.Id,
                        SkillId = CandidateSkill.SkillId
                    };
                    _context.CandidateSkills.Add(candidateskill);

                }
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // POST: api/Candidate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Candidate> PostCandidate(CreateCandidateDTO candidateDTO)
        {

            Candidate candidate = _mapper.Map<Candidate>(candidateDTO);
            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            try
            {
                foreach (var skill in candidateDTO.skills)
                {
                    CandidateSkill candidateSkill = new CandidateSkill
                    {
                        CandidateId = candidate.Id,
                        SkillId = skill
                    };
                    _context.CandidateSkills.Add(candidateSkill);

                }
                _context.SaveChanges();

            }
            catch (DbUpdateException)
            {
                if (CandidateExists(candidate.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }

        // DELETE: api/Candidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidate(string id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        private bool CandidateExists(string id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
