using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoIntegrador.Models
{
    public partial class BDContexto : DbContext
    {
        public BDContexto()
        {
        }

        public BDContexto(DbContextOptions<BDContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Avaliacao> Avaliacaos { get; set; } = null!;
        public virtual DbSet<Disciplina> Disciplinas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=20.226.108.178;Port=3306;User=root;Password=Lucas1122;Database=Jschool", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.62-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.ToTable("avaliacao");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Avaliacao1)
                    .HasColumnType("int(11)")
                    .HasColumnName("avaliacao");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(100)
                    .HasColumnName("comentario");

                entity.Property(e => e.IdDisciplina)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDisciplina");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany(p => p.Avaliacaos)
                    .HasForeignKey(d => d.IdDisciplina)
                    .HasConstraintName("avalicao_ibfk_1");

            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.ToTable("disciplina");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.Professor)
                    .HasMaxLength(60)
                    .HasColumnName("professor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
