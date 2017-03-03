using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("tmovimiento")]
    public class TMovimiento : Generic
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idMovimiento { get; set; }
        [ForeignKey("parentUsuario")]
        public string idUsuario { get; set; }
        [ForeignKey("parentCuenta")]
        public string idCuenta { get; set; }
        [ForeignKey("parentConcepto")]
        public string idConcepto { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string referencia { get; set; }
        public string autorizacion { get; set; }
        public string tipoTransacion { get; set; }
        public string concepto { get; set; }
        public decimal deposito { get; set; }
        public decimal retiro { get; set; }
        public decimal saldo { get; set; }
        #endregion

        #region parent
        public TUsuario parentUsuario { get; set; }
        public TCuenta parentCuenta { get; set; }
        public TConcepto parentConcepto { get; set; }
        #endregion

        #region child
        #endregion
    }
}