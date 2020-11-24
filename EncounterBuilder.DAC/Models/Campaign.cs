using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            Encounters = new HashSet<Encounter>();
        }
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Encounter> Encounters { get; set; }
    }
}
