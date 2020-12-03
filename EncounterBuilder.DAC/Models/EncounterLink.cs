using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class EncounterLink
    {
        public long Id { get; set; }
        public long CurrentHp { get; set; }
        public long EncounterId { get; set; }
        public long CharacterId { get; set; }
        public virtual Encounter Encounter { get; set; }
    }
}
