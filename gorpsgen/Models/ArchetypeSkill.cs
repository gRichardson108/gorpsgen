using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gorpsgen.Models
{
    public class ArchetypeSkill
    {
        public int ID { get; set; }
        public int ArchetypeID { get; set; }
        public int SkillID { get; set; }

        [ForeignKey("ArchetypeID")]
        public Archetype Archetype { get; set; }

        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }
        
    }
}