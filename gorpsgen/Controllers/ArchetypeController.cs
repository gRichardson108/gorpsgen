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
    [Route("api/archetype")]
    public class ArchetypeController : Controller
    {
        readonly QuizContext context;
        public ArchetypeController(QuizContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Archetype a)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Archetypes.Add(a);
            await context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = a.ID }, a);
        }

        [HttpGet]
        public IEnumerable<Models.Archetype> GetArchetypes()
        {
            return context.Archetypes;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var archetype = await context.Archetypes.SingleOrDefaultAsync(m => m.ID == id);

            if (archetype == null)
            {
                return NotFound();
            }

            return Ok(archetype);
        }
    }
}