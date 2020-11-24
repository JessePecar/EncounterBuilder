using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class Attack
    {
        public Attack()
        {
            CharacterActions = new HashSet<CharacterActions>();
        }

        public long AttackId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Damage { get; set; }
        public long Range { get; set; }
        public long DamageType { get; set; }
        public long SavingThrow { get; set; }
        public long ThrowType { get; set; }
        public long SpellDamageType { get; set; }

        public virtual ICollection<CharacterActions> CharacterActions { get; set; }
    }
}
