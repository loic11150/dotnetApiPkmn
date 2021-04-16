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
    public class AbilityController : ControllerBase
    {
        private readonly AbilityContext _context;

        public AbilityController(AbilityContext context)
        {
            _context = context;
        }

        // GET: api/Ability
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ability>>> GetAbility()
        {
            return await _context.Ability.ToListAsync();
        }

        // GET: api/Ability/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ability>> GetAbility(int id)
        {
            var ability = await _context.Ability.FindAsync(id);

            if (ability == null)
            {
                return NotFound();
            }

            return ability;
        }

        // PUT: api/Ability/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbility(int id, Ability ability)
        {
            if (id != ability.Id)
            {
                return BadRequest();
            }

            _context.Entry(ability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilityExists(id))
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

        // POST: api/Ability
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ability>> PostAbility(Ability ability)
        {
            if (ability.Effect == null || ability.Name == null || ability.Name == "" || ability.Effect == "" ){
                return BadRequest("Some required fields are empty (Effect or Name)");
            }
            _context.Ability.Add(ability);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbility", new { id = ability.Id }, ability);
        }

        // DELETE: api/Ability/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbility(int id)
        {
            var ability = await _context.Ability.FindAsync(id);
            if (ability == null)
            {
                return NotFound();
            }

            _context.Ability.Remove(ability);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbilityExists(int id)
        {
            return _context.Ability.Any(e => e.Id == id);
        }
    }
}
