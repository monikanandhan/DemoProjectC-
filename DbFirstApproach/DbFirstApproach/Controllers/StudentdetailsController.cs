using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbFirstApproach.Model;

namespace DbFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentdetailsController : ControllerBase
    {
        private readonly studentContext _context;

        public StudentdetailsController(studentContext context)
        {
            _context = context;
        }

        // GET: api/Studentdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studentdetail>>> GetStudentdetails()
        {
          if (_context.Studentdetails == null)
          {
              return NotFound();
          }
            return await _context.Studentdetails.ToListAsync();
        }

        // GET: api/Studentdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studentdetail>> GetStudentdetail(int id)
        {
          if (_context.Studentdetails == null)
          {
              return NotFound();
          }
            var studentdetail = await _context.Studentdetails.FindAsync(id);

            if (studentdetail == null)
            {
                return NotFound();
            }

            return studentdetail;
        }

        // PUT: api/Studentdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentdetail(int id, Studentdetail studentdetail)
        {
            if (id != studentdetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentdetailExists(id))
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

        // POST: api/Studentdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Studentdetail>> PostStudentdetail(Studentdetail studentdetail)
        {
          if (_context.Studentdetails == null)
          {
              return Problem("Entity set 'studentContext.Studentdetails'  is null.");
          }
            _context.Studentdetails.Add(studentdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentdetail", new { id = studentdetail.Id }, studentdetail);
        }

        // DELETE: api/Studentdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentdetail(int id)
        {
            if (_context.Studentdetails == null)
            {
                return NotFound();
            }
            var studentdetail = await _context.Studentdetails.FindAsync(id);
            if (studentdetail == null)
            {
                return NotFound();
            }

            _context.Studentdetails.Remove(studentdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentdetailExists(int id)
        {
            return (_context.Studentdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
