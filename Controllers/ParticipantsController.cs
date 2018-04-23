using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using seminarapi.Data;
using seminarapi.Models;

namespace seminarapi.Controllers
{
    [Produces("application/json")]
    [Route("api/Participants")]
    public class ParticipantsController : Controller
    {
        private readonly SeminarContext _context;

        public ParticipantsController(SeminarContext context)
        {
            _context = context;
        }

        // GET: api/Participants
        [HttpGet]
        public IEnumerable<Participant> GetParticipants()
        {
            return _context.Participants;
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participant = await _context.Participants.SingleOrDefaultAsync(m => m.ID == id);

            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }

        // PUT: api/Participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant([FromRoute] int id, [FromBody] Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participant.ID)
            {
                return BadRequest();
            }

            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participants
        [HttpPost]
        public async Task<IActionResult> PostParticipant([FromBody] Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipant", new { id = participant.ID }, participant);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participant = await _context.Participants.SingleOrDefaultAsync(m => m.ID == id);
            if (participant == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return Ok(participant);
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(e => e.ID == id);
        }
    }
}