using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gorpsgen
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

        public DbSet<Models.Question> Questions { get; set; }
        public DbSet<Models.Quiz> Quizzes { get; set; }
    }
}