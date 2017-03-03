using appMexicaERP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("cat_categoria_puesto")]
    public class TPuesto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPuesto { get; set; }
        [Required(ErrorMessage = "Clave categoria obligatoria <br>")]
        public string categoria { get; set; }
        public string descripcion { get; set; }
        [Required(ErrorMessage = "Descripcion de la categoria <br>")]

        public string alcancePuesto { get; set; }
        [Required(ErrorMessage = "Indique numero de horas a laborar <br>")]
        public int horas { get; set; }
        [Required(ErrorMessage = "El costo mensual es requerido<br>")]
        public double costo { get; set; }

        //[RegularExpression("^([a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+.[a-zA-Z0-9])?$", ErrorMessage = "Campo \"Correo electrónico\" incorrecto.<br>")]

        //[MinLength(4, ErrorMessage = "El campo \"Contraseña\" debe tener por lo menos 4 caracteres.<br>")]

        //[MaxLength(16, ErrorMessage = "El campo \"Contraseña\" debe tener como mucho 16 caracteres.<br>")]

    }


}