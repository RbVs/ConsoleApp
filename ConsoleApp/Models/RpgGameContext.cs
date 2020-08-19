using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp.Models
{
    public partial class RpgGameContext : DbContext
    {
        public RpgGameContext()
        {
        }

        public RpgGameContext(DbContextOptions<RpgGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CharacterClass> CharacterClass { get; set; }
        public virtual DbSet<GameUser> GameUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.178.101;Database=RpgGame;persist security info=True;user=TestUser;password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Character_pk")
                    .IsClustered(false);

                entity.HasComment("Table for character informations");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.IdCharacterClass).HasColumnName("ID_CharacterClass");

                entity.Property(e => e.IdGameUser).HasColumnName("ID_GameUser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCharacterClassNavigation)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.IdCharacterClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_CharacterClass");

                entity.HasOne(d => d.IdGameUserNavigation)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.IdGameUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_GameUser");
            });

            modelBuilder.Entity<CharacterClass>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("CharacterClass_pk")
                    .IsClustered(false);

                entity.HasComment("Table holds all default informations for character classes");

                entity.HasIndex(e => e.Id)
                    .HasName("CharacterClass_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GameUser>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
