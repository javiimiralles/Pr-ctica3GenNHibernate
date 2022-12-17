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
    }
}