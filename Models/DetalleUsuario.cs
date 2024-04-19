using System.ComponentModel.DataAnnotations;

namespace DatabaseFirst.Models
{
    public class DetalleUsuario
    {
        [Key]
        public int DetalleUsuario_Id { get; set; }
        [Required]
        //[StringLength(50, ErrorMessage = "Las descripción no debe superar los 50 caracteres")]
        public string Cedula { get; set; }

        [Required]
        public string Deporte { get; set; }

        [Required]
        public string Mascota { get; set; }

        public Usuario usuario { get; set; }
    }
}
