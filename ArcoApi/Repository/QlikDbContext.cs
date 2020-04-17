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

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewQlikAuditOperativoAccesso>(entity =>
            {
                entity.HasNoKey();
                //entity.ToView("ViewQlikAuditOperativoAccesso");
            });

            modelBuilder.Entity<ViewQlikDatiPraticaAudit>(entity =>
            {
                entity.HasNoKey();
                //entity.ToView("ViewQlikDatiPraticaAudit");
            });

            modelBuilder.Entity<ViewQlikPraticaGruppo>(entity =>
            {
                entity.HasNoKey();
                //entity.ToView("ViewQlikPraticaGruppo");
            });

            modelBuilder.Entity<ViewQlikRilievo>(entity =>
            {
                entity.HasNoKey();
                //entity.ToView("ViewQlikRilievo");
            });

            modelBuilder.Entity<ViewQlikTeam>(entity =>
            {
                entity.HasNoKey();
                //entity.ToView("ViewQlikTeam");
            });

            modelBuilder.Entity<ViewQlikSede>(entity =>
            {
                entity.HasNoKey();
                //entity.ToView("ViewQlikSede");
            });

            modelBuilder.Entity<ViewQlikDomandaValore>(entity =>
            {
                entity.HasNoKey();
                //entity.ToView("ViewQlikDomandaValore");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
