

using EncounterBuilder.Models.General;

namespace EncounterBuilder.Models.Weapons
{
    public class Attack
    {
        /// <summary>
        /// Name of Attack
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of weapon
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// How much dice and which dice
        /// </summary>
        public string Damage { get; set; }
        
        /// <summary>
        /// Range of the attack
        /// </summary>
        public int Range { get; set; }
        /// <summary>
        /// Type of damage it will do
        /// </summary>
        public DamageType DamageType { get; set; }
        /// <summary>
        /// Number needed for the saving throw
        /// </summary>
        public int SavingThrow { get; set; }
        /// <summary>
        /// Type to use with the modifier
        /// </summary>
        public SavingThrowTypes ThrowType { get; set; }
        /// <summary>
        /// The damage profile of the spell
        /// </summary>
        public SpellType SpellDamageType { get; set; }
    }
}
