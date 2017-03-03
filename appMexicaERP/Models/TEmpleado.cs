using appMexicaERP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("empleado")]
    public class TEmpleado
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idEmpleado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaIngreso { get; set; }

        [ForeignKey("parentcatEmpresas")]
        public int idEmpresa { get; set; }
        public int idTipoEmpleado { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string tipoSangre { get; set; }
        public string curp { get; set; }
        public string rfc { get; set; }
        public int nacionalidad { get; set; }
        public int idCiudad { get; set; }
        public string domicilio { get; set; }
        public string numero { get; set; }
        public int cp { get; set; }
        public string colonia { get; set; }
        public string municipio { get; set; }
        public int idCiudad2 { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public int idIdentificacion { get; set; }
        public string numIdentificacion { get; set; }
        public DateTime fechaBaja { get; set; }
        public string motivoBaja { get; set; }
        public int estatus { get; set; }
        public string foto { get; set; }

        #region Parent
        public TEmpresa parentcatEmpresas { get; set; }
        #endregion

        #region child
        #endregion

    }
}