using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appMexicaERP.Models
{
    [Table("tcuenta")]
    public class TCuenta : Generic
    {
        #region parent
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string idCuenta { get; set; }
        [ForeignKey("parentEmpresa")]  
        public int idEmpresa { get; set; }
        [Required(ErrorMessage = "El campo referencia es obligatorio <br>")]
        public string referencia { get; set; }
        [Required(ErrorMessage = "El campo número de cuenta es obligatorio <br>")]
        [RegularExpression("[0-9]{1,9}(.[0-9]{0,2})?$", ErrorMessage = "El campo No. Cuenta solo permito números")]
        public int numeroCuenta { get; set; }
        [Required(ErrorMessage = "El campo observación es obligatorio <br>")]
        public string observacion { get; set; }
        [Required(ErrorMessage = "El campo saldo inicial es obligatorio <br>")]
        [RegularExpression(@"[0-9]{1,9}(\.[0-9]{0,2})?$", ErrorMessage = "El campo Saldo Inicial solo acepta números decimales")]
        public decimal saldoInicial { get; set; }
        public decimal saldoTotal { get; set; }
        [Required(ErrorMessage = "El campo saldo fecha es obligatorio <br>")]
        public DateTime fecha { get; set; }
        #endregion

        #region parent
        public TEmpresa parentEmpresa { get; set; }
        #endregion

        #region child
        [ForeignKey("idCuenta")]
        public List<TMovimiento> childMovimieto { get; set; }
        #endregion

    }
}