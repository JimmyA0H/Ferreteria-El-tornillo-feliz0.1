
using Ferreteria.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Infrastructure.Data;

public class FerreteriaDbContext : DbContext
{
    public FerreteriaDbContext(DbContextOptions<FerreteriaDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Herramienta> Herramientas => Set<Herramienta>();
    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    public DbSet<Compra> Compras => Set<Compra>();
    public DbSet<CompraDetalle> CompraDetalles => Set<CompraDetalle>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<VentaDetalle> VentaDetalles => Set<VentaDetalle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>().Property(c => c.Nombre).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Herramienta>().Property(h => h.Nombre).HasMaxLength(150).IsRequired();
        modelBuilder.Entity<Proveedor>().Property(p => p.Nombre).HasMaxLength(150).IsRequired();

        // Relaciones simples
        modelBuilder.Entity<Herramienta>()
            .HasOne(h => h.Categoria)
            .WithMany()
            .HasForeignKey(h => h.CategoriaId);

        modelBuilder.Entity<CompraDetalle>()
            .HasOne(d => d.Compra)
            .WithMany(c => c.Detalles)
            .HasForeignKey(d => d.CompraId);

        modelBuilder.Entity<CompraDetalle>()
            .HasOne(d => d.Herramienta)
            .WithMany()
            .HasForeignKey(d => d.HerramientaId);

        modelBuilder.Entity<VentaDetalle>()
            .HasOne(d => d.Venta)
            .WithMany(v => v.Detalles)
            .HasForeignKey(d => d.VentaId);

        modelBuilder.Entity<VentaDetalle>()
            .HasOne(d => d.Herramienta)
            .WithMany()
            .HasForeignKey(d => d.HerramientaId);
    }
}
