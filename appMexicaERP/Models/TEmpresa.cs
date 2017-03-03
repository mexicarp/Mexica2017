﻿using appMexicaERP;
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
        public DateTime fechaCreacion { get; set; }
        public string descripcion { get; set; }
        public string domicilio { get; set; }
        public string numero { get; set; }
        public int cp { get; set; }
        public string colonia { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }
        public long IdEmpleado { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string cve_user { get; set; }
        public int estatus { get; set; }

        #region Parent
        #endregion

        #region child
        [ForeignKey("idEmpresa")]
        public virtual List<TEmpleado> childcatEmpleado { get; set; }
        #endregion

    }
}