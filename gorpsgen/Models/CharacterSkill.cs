using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gorpsgen.Models
{
    public class CharacterSkill
    {
        public int ID { get; set; }
        public int SkillID { get; set; }

        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }
        
        public int CharacterSheetID { get; set; }

        [ForeignKey("CharacterSheetID")]
        public CharacterSheet CharacterSheet { get; set; }
        public int PointsInvested { get; set; }
    }
}