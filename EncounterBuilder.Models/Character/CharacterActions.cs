using System;
using System.Collections.Generic;
using System.Text;
using EncounterBuilder.Models.Weapons;

namespace EncounterBuilder.Models.Character
{
    public class CharacterActions
    {
        public bool IsWeaponAttack { get; set; }
        public Attack CharacterAttack { get; set; }
    }
}
