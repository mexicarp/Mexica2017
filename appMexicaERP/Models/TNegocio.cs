using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("tnegocio")]
    public class TNegocio : Generic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        #region propieties
        public string idNegocio { get; set; }
        [ForeignKey("parentBanco")]
        public string idBanco { get; set; }
        [Required(ErrorMessage = "El campo Negocio es obligatorio")]
        public string nombre { get; set; }
        #endregion

        #region Parent
        public TBanco parentBanco { get; set; }
        #endregion

        #region Children
        [ForeignKey("idNegocio")]
        public virtual List<TCuenta> childCuenta { get; set; }
        #endregion

    }
}