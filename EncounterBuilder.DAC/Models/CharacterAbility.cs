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
        public int Id { get; set; }
        /// <summary>
        /// Title of the ablility
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description of the abililty
        /// </summary>
        public string Description { get; set; }
    }
}
