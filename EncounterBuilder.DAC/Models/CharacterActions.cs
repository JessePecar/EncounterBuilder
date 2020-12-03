using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class CharacterActions
    {
        public long CharacterActionsId { get; set; }
        public long IsWeaponAttack { get; set; }
        public long? CharacterAttackId { get; set; }

        public virtual ICollection<ActionsLink> ActionsLinks { get; set; }
        public virtual Attack CharacterAttack { get; set; }
    }
}
