using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class CharacterStats
    {
        public long CharacterStatsId { get; set; }
        public long CharacterId { get; set; }
        public long Strength { get; set; }
        public long StrengthModifier { get; set; }
        public long Dexterity { get; set; }
        public long DexterityModifier { get; set; }
        public long Constitution { get; set; }
        public long ConstitutionModifier { get; set; }
        public long Intelligence { get; set; }
        public long IntelligenceModifier { get; set; }
        public long Wisdom { get; set; }
        public long WisdomModifier { get; set; }
        public long Charisma { get; set; }
        public long CharismaModifier { get; set; }

        public virtual Character Character { get; set; }
    }
}
