using EncounterBuilder.DAC.Models;
using Microsoft.EntityFrameworkCore;

namespace EncounterBuilder.DAC
{
    public partial class EncounterBuilderDbContext : DbContext
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionsLink>(entity =>
            {
                entity.ToTable("ActionsLink");

                entity.Property(e => e.CharacterActionsId).HasColumnType("bigint");

                entity.Property(e => e.CharacterId).HasColumnType("bigint");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CharacterAbility>(entity =>
            {
                entity.ToTable("CharacterAbility");
            });

            modelBuilder.Entity<CharacterActions>(entity =>
            {
                entity.HasKey(e => e.CharacterActionsId);

                entity.HasIndex(e => e.CharacterAttackId, "IX_CharacterActions_CharacterAttackAttackId");

                entity.HasOne(d => d.CharacterAttack)
                    .WithMany(p => p.CharacterActions)
                    .HasForeignKey(d => d.CharacterAttackId);
            });

            modelBuilder.Entity<CharacterStats>(entity =>
            {
                entity.HasKey(e => e.CharacterStatsId);

                entity.HasOne(cs => cs.Character).WithOne(c => c.Stats);
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(c => c.CharacterId);

                entity.HasOne(c => c.Stats).WithOne(s => s.Character);

                entity.HasOne(c => c.Ability).WithOne(s => s.Character);

                entity.HasMany(c => c.Actions).WithOne(a => a.Character);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
