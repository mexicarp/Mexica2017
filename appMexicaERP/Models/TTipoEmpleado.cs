using appMexicaERP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("cat_tipo_empleado")]

    public class TTipoEmpleado
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoEmpleado { get; set; }

        public string descripcion { get; set; }
        public int estatus { get; set; }

    }
}