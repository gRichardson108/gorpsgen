using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gorpsgen.Models
{
    public class CharacterSheet
    {
        public int ID { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Health { get; set; }

        public int ArchetypeID { get; set; }

        [ForeignKey("ArchetypeID")]
        public Archetype Archetype { get; set; }

        public List<Skill> Skills { get; set; }

        public string UserSub { get; set; }
    }
}