using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("cat_tours")]
    public class TTour
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int id_tour { get; set; }//Campos de la tabla
        //[Column("cmp_Producto")] PARA PODER CAMBIAR DE NOMBRE
        public int id_categoria_tour { get; set; }        
        public string tour { get; set; }
        public string costo_axkan { get; set; }
        public string costo_agencia { get; set; }
        #endregion

        //Relaciones de tablas
        #region child
        [ForeignKey("idTour")]
        public virtual List<TPaqueteDetalle> childPaqueteDetalle { get; set; }
        #endregion

    }
}