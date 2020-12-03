using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class Encounter
    {
        public Encounter()
        {
            EncounterLinks = new HashSet<EncounterLink>();
        }

        public long Id { get; set; }
        public long InitialCharacterCount { get; set; }
        public string Name { get; set; }
        public long CampaignId { get; set; }

        public virtual ICollection<EncounterLink> EncounterLinks { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
