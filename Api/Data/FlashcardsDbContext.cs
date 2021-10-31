using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

#nullable disable

namespace Api
{
    public partial class FlashcardsDbContext : DbContext
    {
        public FlashcardsDbContext()
        {
        }

        public FlashcardsDbContext(DbContextOptions<FlashcardsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<Flashcard> Flashcards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Deck>(entity =>
            {
                entity.HasIndex(e => e.Name, "UC_Decks")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flashcard>(entity =>
            {
                entity.HasIndex(e => e.Phrase, "UC_Flashcards")
                    .IsUnique();

                entity.Property(e => e.Phrase)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Translation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Deck)
                    .WithMany(p => p.Flashcards)
                    .HasForeignKey(d => d.DeckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flashcards");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
