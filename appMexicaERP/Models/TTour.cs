using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("tours")]
    public class TTour
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int idTour { get; set; }//Campos de la tabla
        //[Column("cmp_Producto")] PARA PODER CAMBIAR DE NOMBRE
        public int idCategoriaTour { get; set; }
        public int tipo { get; set; }
        public string tour { get; set; }
        public string costoMexica { get; set; }
        #endregion

        //Relaciones de tablas
        #region child
        [ForeignKey("idTour")]
        public virtual List<TPaqueteDetalle> childPaqueteDetalle { get; set; }
        #endregion

    }
}