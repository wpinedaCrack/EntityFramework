﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseFirst.Models
{
    [Table("Tbl_Articulo")]
    public class Articulo
    {
        [Key]
        public int Articulo_Id { get; set; }

        [Column("Articulo")]
        [Required (ErrorMessage ="El título es obligatorio")]

        [MaxLength(20)]
        public string TituloArticulo { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="Las descripción no debe superar los 50 caracteres")]
        public string Descripcion { get; set; }

        [Range(0.1, 5.0)]
        public string Calificacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //Agregar LLave Foranea
        [ForeignKey ("Categoria")]
        public int Categoria_Id { get; set; }
        public Categoria Categoria { get; set; }
        //Relacion Muchos a Muchos
        public ICollection<ArticuloEtiqueta> ArticuloEtiquetas { get; set; }
    }
}
