using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMexicaERP.Models
{
    [Table("ttour")]
    public class TTourCat
    {
        #region propieties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Identity  PARA CUANDO SE UTILIZA EL AUTO_INCREMENT Y CUANDO NO NONE
        public int idTour { get; set; }//Campos de la tabla   
        [ForeignKey("parenCategoriaTours")]   
        public int idcategoriatour { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string tour { get; set; }
        public string descripcion { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string horaSalida { get; set; }
        public string horaRegreso { get; set; }
        public string duracion { get; set; }
        public int lunes { get; set; }
        public int martes { get; set; }
        public int miercoles { get; set; }
        public int jueves { get; set; }
        public int viernes { get; set; }
        public int sabado { get; set; }
        public int domingo { get; set; }
        public double km { get; set; }
        public double gas { get; set; }
        public double casetas { get; set; }
        public double extra { get; set; }
        public double numPasajeros { get; set; }
        public int estatus { get; set; }
        #endregion

        #region Parent
        public TCategoriaTours parenCategoriaTours { get; set; }
        #endregion

        #region child
        [ForeignKey("idTour")]
        public virtual List<TAgencia> childAgencias { get; set; }
        [ForeignKey("idTour")]
        public virtual List<TPrecio> childPrecios { get; set; }
        #endregion

    }
}