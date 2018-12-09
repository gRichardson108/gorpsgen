using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gorpsgen.Controllers
{
    [Produces("application/json")]
    [Route("api/question")]
    public class QuestionsController : Controller
    {
        readonly QuizContext context;
        public QuestionsController(QuizContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Question question)
        {
            var quiz = context.Quizzes.SingleOrDefault(q => q.ID == question.QuizId);
            if (quiz == null)
            {
                return NotFound(question.QuizId);
            }
            else
            {
                context.Questions.Add(question);
                await context.SaveChangesAsync();
                return Ok(question);
            }
        }

        [HttpGet]
        public IEnumerable<Models.Question> Get()
        {
            return context.Questions;
        }

        [HttpGet("{quizId}")]
        public IEnumerable<Models.Question> Get([FromRoute] int quizId)
        {
            return context.Questions.Where(q => q.QuizId == quizId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Models.Question question)
        {
            // check for ID mismatch
            if (id != question.ID)
            {
                return BadRequest();
            }
            // indicate that the question has been edited
            context.Entry(question).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(question);
        }
    }
}