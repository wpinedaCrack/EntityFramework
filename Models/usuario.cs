using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Models
{
    [Table("usuario")]
    public partial class Usuario
    {
        [Key]
        public int id { get; set; }

        //[Required(ErrorMessage = "El campo Correo electrónico es obligatorio.")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "El campo Correo electrónico no es una dirección de correo electrónico válida.")]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Por favor ingrese un email correcto")]

        [EmailAddress (ErrorMessage = "Por favor ingrese un email correcto")]
        public string email { get; set; } = null!;
        
        public string Nombre { get; set; } = null!;

        [Display(Name = "Dirección del usuario")]
        public string Direccion { get; set; }
        [NotMapped]
        public int Edad { get; set; }

        //Relación Uno a Uno.
        [ForeignKey("DetalleUsuario")]
        public int DetalleUsuario_Id { get; set; }
        public DetalleUsuario DetalleUsuario { get; set; }
    }
}
