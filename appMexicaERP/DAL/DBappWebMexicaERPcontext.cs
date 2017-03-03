using appMexicaERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace appMexicaERP.DAL
{
    public class DBappWebMexicaERPcontext : DbContext
    {
        public DBappWebMexicaERPcontext() : base(nameOrConnectionString: "DBappWebMexicaERPcontext")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<TUsuario> Usuarios { get; set; }
        public DbSet<TBanco> Bancos { get; set; }
        public DbSet<TCuenta> Cuentas { get; set; }
        public DbSet<TMovimiento> Movimientos { get; set; }
        public DbSet<TNegocio> Negocios { get; set; }
        public DbSet<TConcepto> Conceptos { get; set; }

        public DbSet<TVenta> Ventas { get; set; }
        public DbSet<TTour> Tours { get; set; }
        public DbSet<TFormaPago> FormaPagos { get; set; }
        public DbSet<TPaquete> Paquetes { get; set; }
        public DbSet<TPaqueteDetalle> PaqueteDetalles { get; set; }

        public DbSet<TFlotilla> flotillas { get; set; }
        public DbSet<TPuesto> puestos { get; set; }
        public DbSet<TEmpleado> empleados { get; set; }
        public DbSet<TTipoIdentificacion> tipoidentificaciones { get; set; }
        public DbSet<TMarca> marcavehiculos { get; set; }
        public DbSet<TCombustible> combustibles { get; set; }
        public DbSet<TEmpresa> empresas { get; set; }
        public DbSet<TTipoEmpleado> tiposempleados { get; set; }
        public DbSet<TControlVehicular> ctrolvehiculares { get; set; }
        public DbSet<TCiudad> ciudades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}