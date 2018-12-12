using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gorpsgen.Models
{
    public class QuizResponse
    {
        public int ID { get; set; }

        public int RatioCombat { get; set; }
        public int RatioMagic { get; set; }
        public int RatioStealth { get; set; }
        public int QuizID { get; set; }

        [ForeignKey("QuizID")]
        public Quiz Quiz { get; set; }

        //user ID from AWS cognito claims
        public string UserSub { get; set; }
    }
}