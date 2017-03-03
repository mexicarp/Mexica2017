using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("tusuario")]
    public class TUsuario : Generic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        #region propieties
        public string idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string fotoPerfil { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio <br>")]
        [RegularExpression("^([a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+.[a-zA-Z0-9])?$", ErrorMessage = "Campo \"Correo electrónico\" incorrecto.<br>")]
        public string correoElectronico { get; set; }
        public int rol { get; set; }
        public string permisos { get; set; }
        public string codigoVerificacion { get; set; }
        public DateTime fechaInicioCodigoVerificacion { get; set; }
        public DateTime fechaFinalCodigoVerificacion { get; set; }
        #endregion

        #region Parent
        #endregion

        #region Children
        [ForeignKey("idUsuario")]
        public List<TMovimiento> childMovimiento { get; set; }
        #endregion

    }
}