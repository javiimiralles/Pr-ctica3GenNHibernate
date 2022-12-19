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
            linped.NombreProducto = en.Producto.Nombre;
            linped.Imagen = en.Producto.Imagen;
            linped.PrecioUnitario = en.Producto.Precio;
            linped.Valoracion = en.Producto.ValoracionMedia;
            linped.Genero = en.Producto.Genero.Nombre;
            linped.ImporteTotal = en.Pedido.PrecioTotal;

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