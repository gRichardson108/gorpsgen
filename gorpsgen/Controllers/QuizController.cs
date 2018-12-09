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
    [Route("api/quiz")]
    public class QuizController : Controller
    {
        readonly QuizContext context;
        public QuizController(QuizContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.Claims.First();            

            context.Quizzes.Add(quiz);
            await context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = quiz.ID }, quiz);
        }

        [HttpGet]
        public IEnumerable<Models.Quiz> Get()
        {
            return context.Quizzes;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await context.Quizzes.SingleOrDefaultAsync(m => m.ID == id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Models.Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != quiz.ID)
            {
                return BadRequest();
            }
            // indicate that the Quiz has been edited
            context.Entry(quiz).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
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
        private bool QuizExists(int id)
        {
            return context.Quizzes.Any(e => e.ID == id);
        }
    }
}