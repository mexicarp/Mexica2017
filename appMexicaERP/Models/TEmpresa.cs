using appMexicaERP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("cat_empresas")]
    public class TEmpresa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idEmpresa { get; set; }
        public int idTipoEmpresa { get; set; }
        [ForeignKey("parentBanco")]
        public string idBanco { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string descripcion { get; set; }
        public string domicilio { get; set; }
        public string numero { get; set; }
        public int cp { get; set; }
        public string colonia { get; set; }
        public string municipio { get; set; }
        public int idCiudad { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int estatus { get; set; } //1 es activo y 0 inactivo

        #region Parent
        public TBanco parentBanco { get; set; }
        #endregion

        #region child
        [ForeignKey("idEmpresa")]
        public virtual List<TEmpleado> childcatEmpleado { get; set; }
        public virtual List<TCuenta> childCuentas { get; set; }
        #endregion

    }
}