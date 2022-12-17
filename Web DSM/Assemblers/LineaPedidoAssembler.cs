using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DSM.Models;

namespace Web_DSM.Assemblers
{
    public class LineaPedidoAssembler
    {
        public LineaPedidoViewModel ConvertENToModelUI(LineaPedidoEN en)
        {
            LineaPedidoViewModel linped = new LineaPedidoViewModel();
            linped.Id = en.Id;
            linped.IdProducto = en.Producto.Id;
            linped.IdPedido = en.Pedido.Id;
            linped.Cantidad = en.Cantidad;

            return linped;
        }

        public IList<LineaPedidoViewModel> ConvertListENToModel(IList<LineaPedidoEN> ens)
        {
            IList<LineaPedidoViewModel> linpeds = new List<LineaPedidoViewModel>();
            foreach (LineaPedidoEN en in ens)
            {
                linpeds.Add(ConvertENToModelUI(en));
            }
            return linpeds;
        }
    }
}