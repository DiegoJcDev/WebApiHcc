using Microsoft.EntityFrameworkCore;
using WebApiHcc.Modelo;
using System.Reflection.Emit;

namespace WebApiHcc.Dato
{
    public class HccContexto : DbContext
    {
        public HccContexto(DbContextOptions<HccContexto> options) : base(options)
        {
        }

        public DbSet<Almacen> Tb_HccAlmacen { get; set; }
        public DbSet<CatEstatusOrden> Tb_HccCatEstatusOrden { get; set; }
        public DbSet<Mesa> Tb_HccMesas { get; set; }
        public DbSet<Orden> Tb_HccOrdenes { get; set; }
        public DbSet<OrdenDetalle> Tb_HccOrdenesDetalle { get; set; }
        public DbSet<Producto> Tb_HccProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modeloCreador)
        {
            base.OnModelCreating(modeloCreador);

            // Definir claves primarias
            modeloCreador.Entity<Almacen>().HasKey(a => a.alm_id);
            modeloCreador.Entity<CatEstatusOrden>().HasKey(e => e.catord_id);
            modeloCreador.Entity<Mesa>().HasKey(m => m.mes_id);
            modeloCreador.Entity<Orden>().HasKey(o => o.ord_id);
            modeloCreador.Entity<OrdenDetalle>().HasKey(d => d.orddet_id);
            modeloCreador.Entity<Producto>().HasKey(p => p.pro_id);

            modeloCreador.Entity<Orden>()
            .HasMany(o => o.OrdenesDetalle)
            .WithOne(d => d.Orden)
            .HasForeignKey(d => d.ord_id);
        }
    }
}
