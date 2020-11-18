using System;
using System.Collections.Generic;
using System.Text;
using EncounterBuilder.Models.Weapons;

namespace EncounterBuilder.DAC.Models 
{ 
    public class CharacterActions
    {
        /// <summary>
        /// Unique identifier of the action
        /// </summary>
        public int CharacterActionsId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsWeaponAttack { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Attack CharacterAttack { get; set; }
    }
}
