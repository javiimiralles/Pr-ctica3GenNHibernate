using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_DSM.Models
{
    public class ValoracionViewModel
    {
        [ScaffoldColumn(false)]
        public int IdValoracion { get; set; }

        [ScaffoldColumn(false)]
        public string IdCliente { get; set; }

        [ScaffoldColumn(false)]
        public int IdProducto { get; set; }

        [Required]
        [Display(Name = "Valoracion")]
        [Range(1, 5, ErrorMessage = "La valoración debe estar entre 0 y 5")]
        public double Valoracion { get; set; }

        [Required]
        [Display(Name = "Comentario")]
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

    }
}