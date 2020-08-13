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
    public class StemController : ControllerBase
    {
        private readonly DataContext _context;

        public StemController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Stem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stem>>> GetStems()
        {
            return await _context.Stems.ToListAsync();
        }

        // GET: api/Stem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stem>> GetStem(long id)
        {
            var stem = await _context.Stems.FindAsync(id);

            if (stem == null)
            {
                return NotFound();
            }

            return stem;
        }

        // PUT: api/Stem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStem(long id, Stem stem)
        {
            if (id != stem.StemID)
            {
                return BadRequest();
            }

            _context.Entry(stem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StemExists(id))
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

        // POST: api/Stem
        [HttpPost]
        public async Task<ActionResult<Stem>> PostStem(Stem stem)
        {
            _context.Stems.Add(stem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStem", new { id = stem.StemID }, stem);
        }

        // DELETE: api/Stem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stem>> DeleteStem(long id)
        {
            var stem = await _context.Stems.FindAsync(id);
            if (stem == null)
            {
                return NotFound();
            }

            _context.Stems.Remove(stem);
            await _context.SaveChangesAsync();

            return stem;
        }

        //checken of er al gestemd is door u
        [HttpGet("checkStem")]
        public async Task<ActionResult<Boolean>> checkEmail(int lijstid, int gebruikerid)
        {
            List<Stem> stemmen = await _context.Stems
                .Include(s => s.Item)
                    .ThenInclude(s => s.Lijst)
                .ToListAsync();

            foreach (var item in stemmen)
            {
                if (item.GebruikerID == gebruikerid && item.Item.LijstID == lijstid)
                {
                    return true;
                }
            }
            return false;
        }

        private bool StemExists(long id)
        {
            return _context.Stems.Any(e => e.StemID == id);
        }
    }
}
