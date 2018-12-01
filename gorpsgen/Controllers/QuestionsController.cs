using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public void Post([FromBody] Models.Question question)
        {
            context.Questions.Add(question);
            context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Models.Question> Get()
        {
            return context.Questions;
        }
    }
}