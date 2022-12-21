
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Práctica3GenNHibernate.Exceptions;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;
using Práctica3GenNHibernate.CEN.Práctica3;



namespace Práctica3GenNHibernate.CP.Práctica3
{
public partial class PedidoCP : BasicCP
{
        public void RealizarPago(int p_oid_pedido, string p_oid_cliente, string p_direccion, string p_localidad, string p_provincia, int p_cod_postal, string p_num_tarjeta, double p_imp_total)
        {
            PedidoCAD pedidoCAD = null;
            PedidoCEN pedidoCEN = null;
            ClienteCAD clienteCAD = null;
            ClienteCEN clienteCEN = null;
            ProductoCAD productoCAD = null;
            ProductoCEN productoCEN = null;
            LineaPedidoCAD linpedCAD = null;
            LineaPedidoCEN linpedCEN = null;

            try
            {
                SessionInitializeTransaction();

                pedidoCAD = new PedidoCAD(session);
                pedidoCEN = new PedidoCEN(pedidoCAD);

                clienteCAD = new ClienteCAD(session);
                clienteCEN = new ClienteCEN(clienteCAD);

                productoCAD = new ProductoCAD(session);
                productoCEN = new ProductoCEN(productoCAD);

                linpedCAD = new LineaPedidoCAD(session);
                linpedCEN = new LineaPedidoCEN(linpedCAD);

                PedidoEN pedidoEN = pedidoCEN.ReadOID(p_oid_pedido);
                ClienteEN clienteEN = clienteCEN.ReadOID(p_oid_cliente);

                //Modificamos los valores
                pedidoEN.FechaPedido = DateTime.Now;
                pedidoEN.FechaEntrega = DateTime.Now.AddDays(7);
                pedidoEN.Estado = Enumerated.Práctica3.EstadoPedidoEnum.reparto;
                pedidoEN.Direccion = p_direccion;
                pedidoEN.Localidad = p_localidad;
                pedidoEN.Provincia = p_provincia;
                pedidoEN.CodigoPostal = p_cod_postal;
                pedidoEN.PrecioTotal = p_imp_total;

                //Reinicializamos la cesta
                IList<LineaPedidoEN> cestaVacia = new List<LineaPedidoEN>();
                pedidoCEN.New_("", "", "", 0, "", p_oid_cliente, cestaVacia);

                clienteEN.Puntos = clienteEN.Puntos + (int)p_imp_total / 2;
                clienteEN.Puntos++;

                //Decrementamos el stock de los productos
                IList<LineaPedidoEN> listaLinpeds = pedidoEN.LineaPedido;
                foreach (LineaPedidoEN linped in listaLinpeds)
                {
                    productoCEN.DecrementarStock(linped.Producto.Id, linped.Cantidad);
                }

                pedidoCAD.ModifyDefault(pedidoEN);
                clienteCAD.ModifyDefault(clienteEN);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
        }
        public PedidoCP() : base ()
{
}

public PedidoCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
