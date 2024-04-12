using System.ComponentModel.DataAnnotations;

namespace DatabaseFirst.Models
{
    public class Etiqueta
    {
        [Key]
        public int Etiqueta_Id { get; set; }

        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public ICollection<ArticuloEtiqueta> ArticuloEtiquetas { get; set; }
    }
}
