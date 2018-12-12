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

        public DbSet<Models.ArchetypeSkill> ArchetypeSkills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Quiz>().HasData(TestData.testQuizzes);
            modelBuilder.Entity<Models.Question>().HasData(TestData.testQuestions);
            modelBuilder.Entity<Models.Archetype>().HasData(TestData.testArchetypes);
            modelBuilder.Entity<Models.Skill>().HasData(TestData.testSkills);
            modelBuilder.Entity<Models.ArchetypeSkill>().HasData(TestData.testArchetypeSkills);
        }
    }
}