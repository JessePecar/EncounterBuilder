using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class Character
    {
        public Character()
        {
            ActionsLinks = new HashSet<ActionsLink>();
            CharacterAbilities = new HashSet<CharacterAbility>();
            CharacterStats = new HashSet<CharacterStats>();
            EncounterLinks = new HashSet<EncounterLink>();
        }

        public long CharacterId { get; set; }
        public string Name { get; set; }
        public long Level { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }
        public long MaxHealth { get; set; }
        public long Speed { get; set; }
        public long ArmorClass { get; set; }
        public string Language { get; set; }
        public long Alignment { get; set; }

        public virtual ICollection<ActionsLink> ActionsLinks { get; set; }
        public virtual ICollection<CharacterAbility> CharacterAbilities { get; set; }
        public virtual ICollection<CharacterStats> CharacterStats { get; set; }
        public virtual ICollection<EncounterLink> EncounterLinks { get; set; }
    }
}
