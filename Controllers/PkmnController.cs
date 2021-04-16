using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PkmnApi.Models;

namespace PkmnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PkmnController : ControllerBase
    {
        public static readonly string[] types = {"normal","fighting","flying","poison","ground","rock","bug","ghost","steel","fire","water","grass","electric","psychic","ice","dragon","dark","shadow","fairy"};
        private readonly PkmnContext _context;

        public PkmnController(PkmnContext context)
        {
            _context = context;
        }

        // GET: api/Pkmn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pkmn>>> GetPkmn()
        {
            return await _context.Pkmn.ToListAsync();
        }

        // GET: api/Pkmn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pkmn>> GetPkmn(int id)
        {
            var pkmn = await _context.Pkmn.FindAsync(id);

            if (pkmn == null)
            {
                return NotFound();
            }

            return pkmn;
        }

        // PUT: api/Pkmn/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPkmn(int id, Pkmn pkmn)
        {
            if (id != pkmn.Id)
            {
                return BadRequest();
            }

            _context.Entry(pkmn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PkmnExists(id))
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

        // POST: api/Pkmn
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pkmn>> PostPkmn(Pkmn pkmn)
        {
            

            if ( pkmn.Type == null || pkmn.Name == null || pkmn.Type == "" || pkmn.Name == "" ){
                return BadRequest("Some required fields are empty (Type or Name).");
            }else {
                if (pkmn.Height == 0){
                    pkmn.Height =  5 ;
                }
                if (pkmn.Weight == 0){
                    pkmn.Weight = 5;
                }
                if(!Array.Exists(types,element=>element == pkmn.Type)){
                    return BadRequest("Invalid type.");
                }
            }
            _context.Pkmn.Add(pkmn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPkmn", new { id = pkmn.Id }, pkmn);
        }

        // DELETE: api/Pkmn/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePkmn(int id)
        {
            var pkmn = await _context.Pkmn.FindAsync(id);
            if (pkmn == null)
            {
                return NotFound();
            }

            _context.Pkmn.Remove(pkmn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PkmnExists(int id)
        {
            return _context.Pkmn.Any(e => e.Id == id);
        }
    }
}
