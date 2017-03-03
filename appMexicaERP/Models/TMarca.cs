using appMexicaERP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("cat_marcas_vehiculos")]

    public class TMarca
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMarca { get; set; }
        public int estatus { get; set; }
        public string descripcion { get; set; }


    }
}