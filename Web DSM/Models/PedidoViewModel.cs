using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.Enumerated.Práctica3;

namespace Web_DSM.Models
{
    public class PedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string Email_Cliente { get; set; }

        public DateTime Fecha_Pedido { get; set; }

        public DateTime Fecha_Entrega { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [Required]
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Required]
        [Display(Name = "Código Postal")]
        [DataType(DataType.PostalCode)]
        public int Codigo_Postal { get; set; }

        [Required]
        [Display(Name = "Número de Tarjeta")]
        [DataType(DataType.CreditCard)]
        public string Num_Tarjeta { get; set; }

        [ScaffoldColumn(false)]
        public EstadoPedidoEnum Estado { get; set; }

        [ScaffoldColumn(false)]
        public IList<LineaPedidoEN> LinPeds { get; set; }

        [ScaffoldColumn(false)]
        public double Precio_Total { get; set; }
    }
}