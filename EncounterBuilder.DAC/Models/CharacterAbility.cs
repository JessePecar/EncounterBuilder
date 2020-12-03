using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class CharacterAbility
    {
        public long Id { get; set; }
        public long CharacterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Character Character { get; set; }
    }
}
