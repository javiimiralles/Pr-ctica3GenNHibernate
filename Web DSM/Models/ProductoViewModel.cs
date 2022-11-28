using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_DSM.Models
{
    public class ProductoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string Genero { get; set; }

        [ScaffoldColumn(false)]
        public double ValoracionMedia { get; set; }

        [ScaffoldColumn(false)]
        public IList<string> Comentarios { get; set; }

        
        [ScaffoldColumn(false)]
        public IList<double> ValoracionCliente { get; set; }
        

        [ScaffoldColumn(false)]
        public IList<string> NombreUsuario { get; set; }
        

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción del producto", Description = "Descripción del producto", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Precio del producto", Description = "Precio del producto", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el producto")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Stock del producto", Description = "Stock del producto", Name = "Stock ")]
        [Required(ErrorMessage = "Debe indicar un stock para el producto")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public int Stock { get; set; }

        [Display(Prompt = "Imagen del artículo", Description = "Unidades del artículo", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public string Imagen { get; set; }
    }
}