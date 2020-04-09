using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ArcoApi.Models;

namespace ArcoApi.Repository
{
    public partial class QlikDbContext : DbContext
    {
        public QlikDbContext()
        {
        }

        public QlikDbContext(DbContextOptions<QlikDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditOperativoAccesso> ViewQlikAuditOperativoAccesso { get; set; }
        public virtual DbSet<DatiPraticaAudit> ViewQlikDatiPraticaAudit { get; set; }
        public virtual DbSet<PraticaGruppo> ViewQlikPraticaGruppo { get; set; }
        public virtual DbSet<Rilievo> ViewQlikRilievo { get; set; }
        public virtual DbSet<Team> ViewQlikTeam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3S9IUEO\\DB_LOCALE;Initial Catalog=TeenageWasteland;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditOperativoAccesso>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<DatiPraticaAudit>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<PraticaGruppo>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Rilievo>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
