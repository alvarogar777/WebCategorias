using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCategorias.Models
{
    public class Categoria
    {
        public string CodigoCategoria { get; set; }
        
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}