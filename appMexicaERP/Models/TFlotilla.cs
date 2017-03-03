using appMexicaERP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("flotillas")]

    public class TFlotilla
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idFlotilla { get; set; }
        public int idMarca { get; set; }
        public int modelo { get; set; }
        public string tipo { get; set; }
        public string serie { get; set; }
        public int idCombustible { get; set; }
        public int litros { get; set; }
        public int capacidad { get; set; }
        public long kilometraje { get; set; }
        public string placas { get; set; }
        public string numEconomico { get; set; }
        public int seguro { get; set; }
        public string ciaSeguro { get; set; }
        public double montoPagoSeguro { get; set; }
        public DateTime vigenciaIniciaSeguro { get; set; }
        public DateTime vigenciaFinSeguro { get; set; }

        [ForeignKey("parentEmpresas")]
        public int idEmpresa { get; set; }

        [ForeignKey("parentEmpleados")]
        public long idEmpleado { get; set; }
        public int estatusPago { get; set; }
        public double pagoMensual { get; set; }
        public int diaPagoUnidad { get; set; }
        public string observaciones { get; set; }
        public int estatus { get; set; }


        #region Parent
        public TEmpresa parentEmpresas { get; set; }
        public TEmpleado parentEmpleados { get; set; }
        #endregion

        #region child
        [ForeignKey("idFlotilla")]
        public virtual List<TControlVehicular> childControlVehicular { get; set; }
        #endregion

    }


}