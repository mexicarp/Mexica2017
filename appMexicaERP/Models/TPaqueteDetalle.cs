using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("paquete_detalles")]
    public class TPaqueteDetalle
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int idDetallePaquete { get; set; }//Campos de la tabla
        //[Column("cmp_Producto")] PARA PODER CAMBIAR DE NOMBRE
        public int idPaquete { get; set; }
        public int idTour { get; set; }
        public int estatus { get; set; }
        #endregion

        #region Parent
        public TPaquete parenPaquete { get; set; }
        public TTour parenTour { get; set; }
        #endregion



        #region Children
        //[ForeignKey("idNegocio")]
        //public virtual List<TCuenta> childCuenta { get; set; }
        #endregion
    }
}