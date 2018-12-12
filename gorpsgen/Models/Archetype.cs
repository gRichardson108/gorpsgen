using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gorpsgen.Models
{
    public class Archetype
    {
        public int ID { get; set; }
        public int BaseStrength { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseIntelligence { get; set; }
        public int BaseHealth { get; set; }
        public int CombatRating { get; set;}
        public int MagicRating { get; set; }
        public int StealthRating { get; set; }

        public string Name { get; set; }
    }
}