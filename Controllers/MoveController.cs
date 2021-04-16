using System.Runtime.CompilerServices;
using System.Reflection;
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
    public class MoveController : ControllerBase
    {
        public static readonly string[] types = {"normal","fighting","flying","poison","ground","rock","bug","ghost","steel","fire","water","grass","electric","psychic","ice","dragon","dark","shadow","fairy"};
        private readonly MoveContext _context;

        public MoveController(MoveContext context)
        {
            _context = context;
        }

        // GET: api/Move
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Move>>> GetMove()
        {
            return await _context.Move.ToListAsync();
        }

        // GET: api/Move/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Move>> GetMove(int id)
        {
            var move = await _context.Move.FindAsync(id);

            if (move == null)
            {
                return NotFound();
            }

            return move;
        }

        // PUT: api/Move/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMove(int id, Move move)
        {
            if (id != move.Id)
            {
                return BadRequest();
            }

            _context.Entry(move).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(id))
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

        // POST: api/Move
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Move>> PostMove(Move move)
        {
            if(!Array.Exists(types,element=>element == move.Type)){
                    return BadRequest("Invalid type.");
            }
            if (move.Name == null || move.Name == ""){
                 return BadRequest("Some required fields are empty (Name)");
            }
            if (move.Accuracy > 100 || move.Accuracy <= 30 || move.Accuracy%5 != 0){
                return BadRequest("Accuracy must be in range 30 to 100 and modulo 5.");
            }
            if (move.Damage < 0 || move.Damage%10 != 0 || move.Damage > 150){
                 return BadRequest("damage must be in range 0 to 150 and modulo 10.");
            }
            
            _context.Move.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMove", new { id = move.Id }, move);
        }

        // DELETE: api/Move/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMove(int id)
        {
            var move = await _context.Move.FindAsync(id);
            if (move == null)
            {
                return NotFound();
            }

            _context.Move.Remove(move);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoveExists(int id)
        {
            return _context.Move.Any(e => e.Id == id);
        }
    }
}
