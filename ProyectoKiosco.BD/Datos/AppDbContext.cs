using Microsoft.EntityFrameworkCore;
using ProyectoKiosco.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.BD.Datos
{
    public class AppDbContext : DbContext
    {

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Venta_Detalle> Ventas_Detalles { get; set; }     
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
