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

        public virtual DbSet<ViewQlikAuditOperativoAccesso> ViewQlikAuditOperativoAccesso { get; set; }
        public virtual DbSet<ViewQlikDatiPraticaAudit> ViewQlikDatiPraticaAudit { get; set; }
        public virtual DbSet<ViewQlikPraticaGruppo> ViewQlikPraticaGruppo { get; set; }
        public virtual DbSet<ViewQlikRilievo> ViewQlikRilievo { get; set; }
        public virtual DbSet<ViewQlikTeam> ViewQlikTeam { get; set; }
        public virtual DbSet<ViewQlikSede> ViewQlikSede { get; set; }
        public virtual DbSet<ViewQlikDomandaValore> ViewQlikDomandaValore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3S9IUEO\\DB_LOCALE;Initial Catalog=TeenageWasteland;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewQlikAuditOperativoAccesso>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ViewQlikDatiPraticaAudit>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ViewQlikPraticaGruppo>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ViewQlikRilievo>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ViewQlikTeam>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ViewQlikSede>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ViewQlikDomandaValore>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
