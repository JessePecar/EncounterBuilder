using EncounterBuilder.Models.General;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncounterBuilder.DAC.Models
{
    public class Character
    {
        public Character()
        {
            Actions = new HashSet<ActionsLink>();
        }
        public long CharacterId { get; set; }
        /// <summary>
        /// Name of the character
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The ideal level for this character to be introduced (should be a min level of party attr)
        /// </summary>
        public int Level { get; set; } 
        /// <summary>
        /// The race that the character will belong to 
        /// </summary>
        public string Race { get; set; } 
        /// <summary>
        /// To allow the user to provide flavor text
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The health the character will be starting out at
        /// </summary>
        public int MaxHealth { get; set; } 
        /// <summary>
        /// Character's speed when moving
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// Armor class that the character will have, change how hard it is to hit this character
        /// </summary>
        public int ArmorClass { get; set; }
        /// <summary>
        /// Character's language(s)
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// The statistics of the character
        /// </summary>
        public CharacterStats Stats { get; set; }
        /// <summary>
        /// List of actions the character has
        /// </summary>
        public ICollection<ActionsLink> Actions { get; set; }
        /// <summary>
        /// The character's special ablility
        /// </summary>
        public CharacterAbility Ability { get; set; }
        /// <summary>
        /// Character's alignment (ex: Lawful Good)
        /// </summary>
        public Alignment Alignment { get; set; }
    }
}
