using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("cat_ciudades")]
    public class TCiudad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCiudad { get; set; }
        public string descripcion { get; set; }


    }
}