using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appMexicaERP.Models
{
    [Table("tconcepto")]
    public class TConcepto : Generic 
    {
        #region properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idConcepto { get; set; }
        public string concepto { get; set; }
        public string descripcion { get; set; }
        #endregion

        #region parent
        #endregion

        #region child
        [ForeignKey("idConcepto")]
        public List<TMovimiento> childMovimientos { get; set; }
        #endregion
    }
}