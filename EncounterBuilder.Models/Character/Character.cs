using EncounterBuilder.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EncounterBuilder.Models.Character
{
    public class Character
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the character
        /// </summary>
        [DefaultValue("Sir Bigglesworth")]
        public string Name { get; set; }
        /// <summary>
        /// The ideal level for this character to be introduced (should be a min level of party attr)
        /// </summary>
        [DefaultValue(1)]
        public int Level { get; set; } = 1;
        /// <summary>
        /// The race that the character will belong to 
        /// </summary>
        [DefaultValue("Human")]
        public string Race { get; set; } = "Human";
        /// <summary>
        /// To allow the user to provide flavor text
        /// </summary>
        [DefaultValue("Emporer of Biggles")]
        public string Description { get; set; }
        /// <summary>
        /// The health the character will be starting out at
        /// </summary>
        [DefaultValue(10)]
        public int MaxHealth { get; set; } = 10;
        /// <summary>
        /// Character's speed when moving
        /// </summary>
        [DefaultValue(30)]
        public int Speed { get; set; } = 30;
        /// <summary>
        /// Armor class that the character will have, change how hard it is to hit this character
        /// </summary>
        [DefaultValue(10)]
        public int ArmorClass { get; set; } = 10;
        /// <summary>
        /// Character's language(s)
        /// </summary>
        [DefaultValue("Common, Goblin")]
        public string Language { get; set; } = "Common, Goblin";
        /// <summary>
        /// The statistics of the character
        /// </summary>
        public CharacterStats Stats { get; set; } = CharacterStats.Default;
        /// <summary>
        /// List of actions the character has
        /// </summary>
        public List<CharacterActions> Actions { get; set; } = new List<CharacterActions>();
        /// <summary>
        /// The character's special ablility
        /// </summary>
        public CharacterAbility Ability { get; set; } = new CharacterAbility();
        /// <summary>
        /// Character's alignment (ex: Lawful Good)
        /// </summary>
        [DefaultValue(Alignment.TrueNeutral)]
        public Alignment Alignment { get; set; } = Alignment.TrueNeutral;
    }
}
