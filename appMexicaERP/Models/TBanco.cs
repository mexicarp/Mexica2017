using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appMexicaERP.Models
{
    [Table("tbanco")]
    public class TBanco : Generic
    {
        #region properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string idBanco { get; set; }
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string nombre { get; set; }
        #endregion

        #region parent
        #endregion

        #region child
        [ForeignKey("idBanco")]
        public virtual List<TNegocio> childNegocio { get; set; }
        #endregion


    }
}