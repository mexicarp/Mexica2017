using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("tagencia")]
    public class TAgencia
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int idAgencia { get; set; }//Campos de la tabla   
        [ForeignKey("parenTourCat")]
        public int idTour { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int estatus { get; set; }
        #endregion

        #region Parent
        public TTourCat parenTourCat { get; set; }
        #endregion

        #region child
        [ForeignKey("idAgencia")]
        public virtual List<TPrecio> childPrecios { get; set; }
        #endregion
    }
}