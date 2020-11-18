using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterBuilder.DAC.Models
{
    public class CharacterAbility
    {
        /// <summary>
        /// Character Ability primary Key
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Id of the character the stats belong to
        /// </summary>
        public long CharacterId { get; set; }
        /// <summary>
        /// Title of the ablility
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description of the abililty
        /// </summary>
        public string Description { get; set; }

        public Character Character { get; set; }
    }
}
