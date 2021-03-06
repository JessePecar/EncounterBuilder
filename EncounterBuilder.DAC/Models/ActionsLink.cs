﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EncounterBuilder.DAC.Models
{
    public partial class ActionsLink
    {
        public long Id { get; set; }
        public long CharacterId { get; set; }
        public long CharacterActionsId { get; set; }

        public virtual Character Character { get; set; }
        public virtual CharacterActions CharacterActions { get; set; }

    }
}
