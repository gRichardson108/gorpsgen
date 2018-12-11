using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gorpsgen.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string CombatAnswer { get; set; }
        public string MagicAnswer { get; set; }
        public string StealthAnswer { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz {get; set; }
    }
}