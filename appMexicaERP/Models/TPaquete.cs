using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("paquetes")]
    public class TPaquete
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int idPaquete { get; set; }//Campos de la tabla
        //[Column("cmp_Producto")] PARA PODER CAMBIAR DE NOMBRE
        public string paquete { get; set; }
        public int numDias { get; set; }
        public int npax { get; set; }
        public double gastoExtra { get; set; }
        public int costoMexica { get; set; }
        #endregion

        #region parent
        #endregion

        //Relaciones de tablas
        #region child
        [ForeignKey("idPaquete")]
        public virtual List<TPaqueteDetalle> childPaqueteDetalle { get; set; }
        #endregion
    }
}