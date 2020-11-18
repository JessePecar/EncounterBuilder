using EncounterBuilder.DAC.Models;
using Microsoft.EntityFrameworkCore;

namespace EncounterBuilder.DAC
{
    public class EncounterBuilderDbContext : DbContext
    {
        #region Constructor

        public EncounterBuilderDbContext(DbContextOptions<EncounterBuilderDbContext> options)
        : base(options)
        {
        }

        #endregion

        #region DBSets

        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterStats> CharacterStats { get; set; }
        public DbSet<CharacterActions> CharacterActions { get; set; }
        public DbSet<CharacterAbility> CharacterAbility { get; set; }
        public DbSet<Attack> Attacks { get; set; }
        public DbSet<ActionsLink> ActionsLink { get; set; }

        #endregion

        #region OnModelCreating

        #endregion
    }
}
