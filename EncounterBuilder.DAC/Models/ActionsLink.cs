using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncounterBuilder.DAC.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionsLink
    {
        public ActionsLink()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; } 
        [Column("CharacterId")]
        public long CharacterId { get; set; }
        public long CharacterActionsId { get; set; }
        public CharacterActions Action { get; set; }
        public Character Character { get; set; }
    }
}
