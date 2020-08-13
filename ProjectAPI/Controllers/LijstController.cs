using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LijstController : ControllerBase
    {
        private readonly DataContext _context;

        public LijstController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Lijst
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lijst>>> GetLijsts()
        {
            return await _context.Lijsts.ToListAsync();
        }

        // GET: api/Lijst/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lijst>> GetLijst(long id)
        {
            var lijst = await _context.Lijsts.FindAsync(id);

            if (lijst == null)
            {
                return NotFound();
            }

            return lijst;
        }

        // PUT: api/Lijst/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLijst(long id, Lijst lijst)
        {
            if (id != lijst.LijstID)
            {
                return BadRequest();
            }

            _context.Entry(lijst).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LijstExists(id))
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

        // POST: api/Lijst
        [HttpPost]
        public async Task<ActionResult<Lijst>> PostLijst(Lijst lijst)
        {
            _context.Lijsts.Add(lijst);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLijst", new { id = lijst.LijstID }, lijst);
        }

        // DELETE: api/Lijst/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lijst>> DeleteLijst(long id)
        {
            var lijst = await _context.Lijsts.FindAsync(id);
            if (lijst == null)
            {
                return NotFound();
            }

            _context.Lijsts.Remove(lijst);
            await _context.SaveChangesAsync();

            return lijst;
        }

        //Detail ophalen
        [HttpGet("LijstDetail/{id}")]
        public async Task<ActionResult<Lijst>> GetLijstDetail(long id)
        {
            var lijst = await _context.Lijsts
                .Include(l => l.Items)
                    .ThenInclude(l => l.Stems)
                .Where(l => l.LijstID == id)
                .FirstOrDefaultAsync();

            return lijst;
        }

        private bool LijstExists(long id)
        {
            return _context.Lijsts.Any(e => e.LijstID == id);
        }
    }
}
