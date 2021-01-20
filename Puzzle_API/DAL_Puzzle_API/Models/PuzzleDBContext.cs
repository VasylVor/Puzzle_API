using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL_Puzzle_API.Models
{
    public partial class PuzzleDBContext : DbContext
    {
        private readonly string connection;
        public PuzzleDBContext()
        {
            connection = ConnectionString.GetConnectionString();
        }

        public PuzzleDBContext(DbContextOptions<PuzzleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Puzzle> Puzzles { get; set; }
        public virtual DbSet<PuzzleError> PuzzleErrors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageValue).HasColumnName("ImageValue");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Puzzle>(entity =>
            {
                entity.ToTable("Puzzle");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PuzzleImg).HasColumnName("PuzzleImg");
            });

            modelBuilder.Entity<PuzzleError>(entity =>
            {
                entity.ToTable("PuzzleError");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.MethodName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Requst)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
