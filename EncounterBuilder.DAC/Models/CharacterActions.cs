
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncounterBuilder.DAC.Models 
{ 
    public class CharacterActions
    {
        public CharacterActions()
        {
            ActionLinks = new HashSet<ActionsLink>();
        }
        public long CharacterActionsId { get; set; }
        public long IsWeaponAttack { get; set; }
        [Column("CharacterAttackAttackId")]
        public long? CharacterAttackId { get; set; }

        public virtual Attack CharacterAttack { get; set; }
        public virtual ICollection<ActionsLink> ActionLinks { get; set; }
    }
}
