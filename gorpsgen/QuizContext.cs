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

        public DbSet<Models.QuizResponse> QuizResponses { get; set; }
        public DbSet<Models.Archetype> Archetypes { get; set; }
        public DbSet<Models.CharacterSheet> CharacterSheets { get; set; }
        public DbSet<Models.CharacterSkill> CharacterSkills { get; set; }
        public DbSet<Models.Skill> Skills { get; set; }
    }
}