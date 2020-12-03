namespace EncounterBuilder.Models.Character
{
    public class CharacterStats
    {
        /// <summary>
        /// Character's Strength
        /// </summary>
        public int Strength { get; set; }
        /// <summary>
        /// Custom Modifier
        /// </summary>
        public int StrengthModifier { get; set; }
        public int StrengthBonus => GetModifier(Strength, nameof(Strength));
        /// <summary>
        /// Character's Charisma
        /// </summary>
        public int Dexterity { get; set; }
        /// <summary>
        /// Custom Modifier
        /// </summary>
        public int DexterityModifier { get; set; }
        public int DexterityBonus => GetModifier(Dexterity, nameof(Dexterity));
        /// <summary>
        /// Charatcter's Constitution
        /// </summary>
        public int Constitution { get; set; }
        /// <summary>
        /// Custom Modifier
        /// </summary>
        public int ConstitutionModifier { get; set; }
        public int ConstitutionBonus => GetModifier(Constitution, nameof(Constitution));
        /// <summary>
        /// Character's Intelligence
        /// </summary>
        public int Intelligence { get; set; }
        /// <summary>
        /// Custom Modifier
        /// </summary>
        public int IntelligenceModifier { get; set; }
        public int IntelligenceBonus => GetModifier(Intelligence, nameof(Intelligence));
        /// <summary>
        /// Character's Wisdom
        /// </summary>
        public int Wisdom { get; set; }
        /// <summary>
        /// Custom Modifier
        /// </summary>
        public int WisdomModifier { get; set; }
        public int WisdomBonus => GetModifier(Wisdom, nameof(Wisdom));
        /// <summary>
        /// Character's Charisma
        /// </summary>
        public int Charisma { get; set; }
        /// <summary>
        /// Custom Modifier
        /// </summary>
        public int CharismaModifier { get; set; }
        public int CharismaBonus => GetModifier(Charisma, nameof(Charisma));
        /// <summary>
        /// The initiative modifier
        /// </summary>
        public int Initiative => GetModifier(Dexterity);
        /// <summary>
        /// Gets the modifier added onto roles with custom modifier
        /// </summary>
        /// <param name="currentStat"></param>
        /// <returns></returns>
        public int GetModifier(int currentStat, string statName)
        {
            int attrModifier = (this.GetType().GetProperty($"{statName}Modifier").GetValue(this, null) as int?).GetValueOrDefault();
            currentStat -= 10;
            attrModifier += currentStat / 2;
            
            return attrModifier;
        }

        /// <summary>
        /// Gets the modifier added onto roles
        /// </summary>
        /// <param name="currentStat"></param>
        /// <returns></returns>
        public int GetModifier(int currentStat)
        {
            int attrModifier = 0;
            currentStat -= 10;
            attrModifier += currentStat / 2;

            return attrModifier;
        }

        public static readonly CharacterStats Default = new CharacterStats()
        {
            Strength = 10,
            Wisdom = 10,
            Intelligence = 10,
            Constitution = 10,
            Charisma = 10,
            Dexterity = 10,
            StrengthModifier = 0,
            CharismaModifier = 0,
            ConstitutionModifier = 0,
            DexterityModifier = 0,
            IntelligenceModifier = 0,
            WisdomModifier = 0
        };
    }
}
