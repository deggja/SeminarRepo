﻿using System;
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
    [Route("api/Instructors")]
    public class InstructorsController : Controller
    {
        private readonly SeminarContext _context;

        public InstructorsController(SeminarContext context)
        {
            _context = context;
        }

        // GET: api/Instructors
        [HttpGet]
        public IEnumerable<Instructor> GetInstructors()
        {
            return _context.Instructors;
        }

        // GET: api/Instructors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var instructor = await _context.Instructors.SingleOrDefaultAsync(m => m.ID == id);

            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);
        }

        // PUT: api/Instructors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor([FromRoute] int id, [FromBody] Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instructor.ID)
            {
                return BadRequest();
            }

            _context.Entry(instructor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorExists(id))
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

        // POST: api/Instructors
        [HttpPost]
        public async Task<IActionResult> PostInstructor([FromBody] Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstructor", new { id = instructor.ID }, instructor);
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var instructor = await _context.Instructors.SingleOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return Ok(instructor);
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.ID == id);
        }
    }
}