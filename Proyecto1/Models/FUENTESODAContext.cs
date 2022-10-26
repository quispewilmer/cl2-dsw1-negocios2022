using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto1.Models
{
    public partial class FUENTESODAContext : DbContext
    {
        public FUENTESODAContext()
        {
        }

        public FUENTESODAContext(DbContextOptions<FUENTESODAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boleta> Boleta { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Cliente { get; set; } = null!;
        public virtual DbSet<Detalleboleta> Detalleboleta { get; set; } = null!;
        public virtual DbSet<Distrito> Distrito { get; set; } = null!;
        public virtual DbSet<Producto> Producto { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedor { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Database");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleta>(entity =>
            {
                entity.HasKey(e => e.NumBol)
                    .HasName("PK__BOLETA__CA2DDD8E6DAB971B");

                entity.HasOne(d => d.IdeCliNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.IdeCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BOLETA__IDE_CLI__30F848ED");

                entity.HasOne(d => d.IdeVenNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.IdeVen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BOLETA__IDE_VEN__31EC6D26");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdeCat)
                    .HasName("PK__CATEGORI__B88A109D9EFF78C9");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdeCli)
                    .HasName("PK__CLIENTE__B88BBBD800095470");

                entity.HasOne(d => d.IdeDisNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdeDis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTE__IDE_DIS__2B3F6F97");
            });

            modelBuilder.Entity<Detalleboleta>(entity =>
            {
                entity.HasKey(e => new { e.NumBol, e.IdePro })
                    .HasName("PK__DETALLEB__847979184FEBBDCE");

                entity.HasOne(d => d.IdeProNavigation)
                    .WithMany(p => p.Detalleboleta)
                    .HasForeignKey(d => d.IdePro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLEBO__IDE_P__35BCFE0A");

                entity.HasOne(d => d.NumBolNavigation)
                    .WithMany(p => p.Detalleboleta)
                    .HasForeignKey(d => d.NumBol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLEBO__NUM_B__34C8D9D1");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdeDis)
                    .HasName("PK__DISTRITO__BA4F52614E9C6D13");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdePro)
                    .HasName("PK__PRODUCTO__E54A49655AF60D0C");

                entity.HasOne(d => d.IdeCatNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdeCat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUCTO__IDE_CA__267ABA7A");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdeVen)
                    .HasName("PK__VENDEDOR__E7CA18824BE18B7E");

                entity.HasOne(d => d.IdeDisNavigation)
                    .WithMany(p => p.Vendedor)
                    .HasForeignKey(d => d.IdeDis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VENDEDOR__IDE_DI__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
