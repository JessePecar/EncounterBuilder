using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.Models.Campaign
{
    public partial class Encounter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long InitialCharacterCount { get; set; }

        public Campaign Campaign { get; set; }
        public List<Character.Character> EncounterCharacters { get; set; }
    }
}
