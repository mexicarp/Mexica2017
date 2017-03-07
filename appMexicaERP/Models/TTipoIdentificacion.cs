using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appMexicaERP.Models
{
    [Table("cat_tipo_identificacion")]
    public class TTipoIdentificacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idIdentificacion { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }
    }
}