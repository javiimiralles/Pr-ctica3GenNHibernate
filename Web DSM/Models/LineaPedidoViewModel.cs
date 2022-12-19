using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_DSM.Models
{
    public class LineaPedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int IdProducto { get; set; }

        [ScaffoldColumn(false)]
        public int IdPedido { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        public string NombreProducto { get; set; }

        public string Imagen { get; set; }

        public double PrecioUnitario { get; set; }

        public double Valoracion { get; set; }

        public string Genero { get; set; }

        public double ImporteTotal { get; set; }
    }
}