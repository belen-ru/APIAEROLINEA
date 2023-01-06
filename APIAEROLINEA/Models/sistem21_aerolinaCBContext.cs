using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIAEROLINEA.Models
{
    public partial class sistem21_aerolinaCBContext : DbContext
    {
        public sistem21_aerolinaCBContext()
        {
        }

        public sistem21_aerolinaCBContext(DbContextOptions<sistem21_aerolinaCBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aeorolinea> Aeorolinea { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Aeorolinea>(entity =>
            {
                entity.ToTable("aeorolinea");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Count).HasColumnType("int(11)");

                entity.Property(e => e.Destination).HasMaxLength(30);

                entity.Property(e => e.Flight).HasMaxLength(7);

                entity.Property(e => e.Gate).HasColumnType("int(2)");

                entity.Property(e => e.Remarks).HasMaxLength(15);

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
