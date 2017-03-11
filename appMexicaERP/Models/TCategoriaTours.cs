using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("tcategoriatour")]
    public class TCategoriaTours
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int idcategoriatour { get; set; }//Campos de la tabla        
        public string descripcion { get; set; }
        #endregion

        //Relaciones de tablas
        #region child
        [ForeignKey("idcategoriatour")]
        public virtual List<TTourCat> childTourCatalogoS { get; set; }
        #endregion
    }
}