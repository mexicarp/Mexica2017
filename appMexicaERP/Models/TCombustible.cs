using appMexicaERP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("cat_combustible")]
    public class TCombustible
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCombustible { get; set; }
        public Double costoLitro { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }

    }
}