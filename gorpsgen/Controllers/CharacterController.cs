using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gorpsgen;
using gorpsgen.Models;

namespace gorpsgen.Controllers
{
    [Produces("application/json")]
    [Route("api/characters")]
    public class CharacterController : Controller
    {
        readonly QuizContext context;
        public CharacterController(QuizContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.CharacterSheet character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.Claims.First();            

            context.CharacterSheets.Add(character);
            await context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = character.ID }, character);
        }

        [HttpGet]
        public IEnumerable<Models.CharacterSheet> Get()
        {
            return context.CharacterSheets.Include(m => m.Archetype);
        }

        [HttpGet("all")]
        public IEnumerable<Models.CharacterSheet> GetAll()
        {
            return context.CharacterSheets.Include(m => m.Archetype);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var character = await context.CharacterSheets.Include(m => m.Archetype).SingleOrDefaultAsync(m => m.ID == id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }
    }
}