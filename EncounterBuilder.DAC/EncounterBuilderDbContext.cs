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
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Encounter> Encounters { get; set; }
        public virtual DbSet<EncounterLink> EncounterLinks { get; set; }

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionsLink>(entity =>
            {
                entity.ToTable("ActionsLink");

                entity.HasOne(d => d.CharacterActions)
                    .WithMany(p => p.ActionsLinks)
                    .HasForeignKey(d => d.CharacterActionsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionsLink_CharacterActions");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.ActionsLinks)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionsLink_Characters");
            });

            modelBuilder.Entity<Attack>(entity =>
            {
                entity.Property(e => e.Damage).HasColumnType("text");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("varchar(1000)");

                entity.Property(e => e.Language).HasColumnType("varchar(50)");

                entity.Property(e => e.Name).IsUnicode(false).HasColumnType("varchar(50)");

                entity.Property(e => e.Race).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<CharacterAbility>(entity =>
            {
                entity.ToTable("CharacterAbility");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Title).HasColumnType("text");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharacterAbilities)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterAbility_Characters");
            });

            modelBuilder.Entity<CharacterActions>(entity =>
            {
                entity.HasKey(e => e.CharacterActionsId);

                entity.HasOne(d => d.CharacterAttack)
                    .WithMany(p => p.CharacterActions)
                    .HasForeignKey(d => d.CharacterAttackId)
                    .HasConstraintName("FK_CharacterActions_Attacks");
            });

            modelBuilder.Entity<CharacterStats>(entity =>
            {
                entity.HasKey(e => e.CharacterStatsId);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharacterStats)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterStats_Characters");
            });

            modelBuilder.Entity<Encounter>(entity =>
            {
                entity.ToTable("Encounter");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Encounter_Campaign");
            });

            modelBuilder.Entity<EncounterLink>(entity =>
            {
                entity.ToTable("EncounterLink");

                entity.Property(e => e.CurrentHp).HasColumnName("CurrentHP");

                entity.HasOne(d => d.Encounter)
                    .WithMany(p => p.EncounterLinks)
                    .HasForeignKey(d => d.EncounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EncounterLink_Encounter");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
