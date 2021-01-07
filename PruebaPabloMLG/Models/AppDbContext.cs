using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaPabloTapia.Model
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<RelClienteTiendum> RelClienteTienda { get; set; }
        public virtual DbSet<Tienda> Tiendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2UHA6RQ\\SQLEXPRESS;Initial Catalog=PruebaTM;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D5946642FEA1761A");

                entity.Property(e => e.Apellidos).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<RelClienteTiendum>(entity =>
            {
                entity.HasKey(e => e.IdRelacion)
                    .HasName("PK__RelClien__D27D6AE70945B238");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.RelClienteTienda)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Cliente");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.RelClienteTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("FK_Tienda");
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PK__Tiendas__5A1EB96B8F8BB344");

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Sucursal).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
