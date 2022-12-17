using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DSM.Models;

namespace Web_DSM.Assemblers
{
    public class PedidoAssembler
    {
        public PedidoViewModel ConvertENToModelUI(PedidoEN en)
        {
            PedidoViewModel pedido = new PedidoViewModel();
            pedido.Id = en.Id;
            pedido.Email_Cliente = en.Cliente.Email;
            pedido.Fecha_Pedido = (DateTime)en.FechaPedido;
            pedido.Fecha_Entrega = (DateTime)en.FechaEntrega;
            pedido.Direccion = en.Direccion;
            pedido.Localidad = en.Localidad;
            pedido.Provincia = en.Provincia;
            pedido.Codigo_Postal = en.CodigoPostal;
            pedido.Num_Tarjeta = en.TipoTarjeta;
            pedido.Estado = en.Estado;
            pedido.LinPeds = en.LineaPedido;
            pedido.Precio_Total = en.PrecioTotal;

            return pedido;
        }

        public IList<PedidoViewModel> ConvertListENToModel(IList<PedidoEN> ens)
        {
            IList<PedidoViewModel> pedidos = new List<PedidoViewModel>();
            foreach (PedidoEN en in ens)
            {
                pedidos.Add(ConvertENToModelUI(en));
            }
            return pedidos;
        }
    }
}