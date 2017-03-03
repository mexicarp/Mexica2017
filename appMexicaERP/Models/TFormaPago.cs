using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("cat_forma_pago")]
    public class TFormaPago
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int idFormaPago { get; set; }//Campos de la tabla
        //[Column("cmp_Producto")] PARA PODER CAMBIAR DE NOMBRE
        public string descripcion { get; set; }
        public int estatus { get; set; }
        #endregion
    }
}