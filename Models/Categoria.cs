﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseFirst.Models
{
    public class Categoria
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Categoria_Id { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText="[NULL]")]
        [Required]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public bool Activo { get; set; }

        public List<Articulo> Articulo { get; set; }
    }
}
