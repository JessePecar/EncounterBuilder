using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterBuilder.DAC.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionsLink
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Relates to the Character
        /// </summary>
        public int CharacterId { get; set; }
        /// <summary>
        /// Unique identifier of the action
        /// </summary>
        public int ActionId { get; set; }
    }
}
