using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("control_vehicular")]
    public class TControlVehicular
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idControl { get; set; }
        [ForeignKey("parentFlotilla")]
        public int idFlotilla { get; set; }
        public string claveServicio { get; set; }
        public string destino { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaSalida { get; set; }
        public string horaSalida { get; set; }
        public Boolean eluces { get; set; }
        public Boolean ecuartoLuces { get; set; }
        public Boolean eantena { get; set; }
        public Boolean eespejoDerecho { get; set; }
        public Boolean eespejoIzquierdo { get; set; }
        public Boolean ecristales { get; set; }
        public Boolean elogoMarca { get; set; }
        public Boolean ellantas4 { get; set; }
        public Boolean etapones4 { get; set; }
        public Boolean emolduras { get; set; }
        public Boolean etaponGas { get; set; }
        public Boolean ecarroceria { get; set; }
        public Boolean eclaxon { get; set; }
        public Boolean itablero { get; set; }
        public Boolean iclima { get; set; }
        public Boolean iplumas { get; set; }
        public Boolean iradio { get; set; }
        public Boolean ipantalla { get; set; }
        public Boolean icamara { get; set; }
        public Boolean ibocinas { get; set; }
        public Boolean iencendedor { get; set; }
        public Boolean iceniceros { get; set; }
        public Boolean icinturones { get; set; }
        public Boolean imanijas { get; set; }
        public Boolean itapetes { get; set; }
        public Boolean ivestiduras { get; set; }
        public Boolean agato { get; set; }
        public Boolean allave { get; set; }
        public Boolean aherramienta { get; set; }
        public Boolean atriangulo { get; set; }
        public Boolean allantarefa { get; set; }
        public Boolean aextinguidor { get; set; }
        public string tanque { get; set; }
        public Boolean tcirculacion { get; set; }
        public Boolean pseguro { get; set; }
        public Boolean tverficacion { get; set; }
        public Boolean licencia { get; set; }
        public long kmSalida { get; set; }
        public long kmEntrada { get; set; }
        public long kmRecorrido { get; set; }
        public DateTime fechaEntrada { get; set; }
        public string horaEntrada { get; set; }
        public string observaciones { get; set; }
        public int estatus { get; set; }

        #region Parent
        public TFlotilla parentFlotilla { get; set; }
        #endregion

        #region child
        #endregion
    }
}