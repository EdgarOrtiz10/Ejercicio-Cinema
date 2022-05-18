using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CinemaApp.Infrastructure.Persistance
{
    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
        {
        }

        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Funcion> Funcions { get; set; } = null!;
        public virtual DbSet<Pelicula> Peliculas { get; set; } = null!;
        public virtual DbSet<Sala> Salas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-KBULVK8; Database = Cinema; Integrated security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura);

                entity.ToTable("DetalleFactura");

                entity.Property(e => e.IdDetalleFactura).ValueGeneratedNever();

                entity.Property(e => e.FechaUso).HasColumnType("datetime");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleFactura_Factura");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Factura");

                entity.Property(e => e.IdFactura).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValorBruto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValorIva).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValorNeto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValorServicio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Factura_Cliente");

                entity.HasOne(d => d.IdFuncionNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdFuncion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Funcion");
            });

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.HasKey(e => e.IdFuncion);

                entity.ToTable("Funcion");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.PrecioBoleta).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Funcions)
                    .HasForeignKey(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcion_Pelicula");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Funcions)
                    .HasForeignKey(d => d.IdSala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcion_Sala");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);

                entity.ToTable("Pelicula");

                entity.Property(e => e.ActorPrincipal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Director)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala);

                entity.ToTable("Sala");

                entity.Property(e => e.Nomenclatura)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
