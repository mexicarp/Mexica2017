using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("tprecios")]
    public class TPrecio
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int idPrecio { get; set; }//Campos de la tabla           
        public int idAgencia { get; set; }
        public int idTour { get; set; }
        public string nombre { get; set; }
        public Double precioALta { get; set; }
        public Double precioBaja { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int estatus { get; set; }
        #endregion

        #region Parent
        public TTourCat parenTours { get; set; }
        public TAgencia parenAgencias { get; set; }
        #endregion
    }
}