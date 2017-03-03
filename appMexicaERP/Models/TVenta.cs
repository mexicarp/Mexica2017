using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("ventas")]
    public class TVenta
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE


        public int idVenta { get; set; }//Campos de la tabla       
        public DateTime fechaRegistro { get; set; }
        public int idEmpleado { get; set; }//Campos de la tabla
        [Required(ErrorMessage = "Debe ingresar un la fecha")]
        public DateTime fechaVenta { get; set; }//Campos de la tabla
        public int idProducto { get; set; }
        public int idTour { get; set; }//Campos de la tabla
        public int idPaquete { get; set; }//Campos de la tabla
        public string tipo_costo { get; set; }
        public Double costoVenta { get; set; }//Campos de la tabla
        [Required(ErrorMessage = "Agregue el costo vendido")]
        public Double costoVendido { get; set; }//Campos de la tabla
        public int adultos { get; set; }
        public int ninos { get; set; }//Campos de la tabla
        public int pax { get; set; }//Campos de la tabla
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }//Campos de la tabla
        public string cliente { get; set; }
        public string telefono { get; set; }//Campos de la tabla
        public string correo { get; set; }//Campos de la tabla
        public string observaciones { get; set; }
        public string recoger { get; set; }//Campos de la tabla
        public int idFormaPago { get; set; }//Campos de la tabla
        public string banco { get; set; }
        public Double total { get; set; }//Campos de la tabla
        public Double anticipo { get; set; }//Campos de la tabla
        public Double saldo { get; set; }//Campos de la tabla
        public Double utilidadBruta { get; set; }
        public Double comisionPagar { get; set; }//Campos de la tabla
        public Double utilidadNeta { get; set; }//Campos de la tabla
        public string referencia { get; set; }//Campos de la tabla
        public DateTime fechaModificacion { get; set; }//Campos de la tabla
        public DateTime fechaCancelacion { get; set; }//Campos de la tabla
        public string motivoCancelacion { get; set; }//Campos de la tabla
        public int estatus { get; set; }//Campos de la tabla
        #endregion

    }
}