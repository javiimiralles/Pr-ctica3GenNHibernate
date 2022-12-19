
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
        public void RealizarPago(int p_oid_pedido, string p_oid_cliente, string p_num_tarjeta)
        {
            PedidoCAD pedidoCAD = null;
            PedidoCEN pedidoCEN = null;
            ClienteCAD clienteCAD = null;
            ClienteCEN clienteCEN = null;
            ProductoCAD productoCAD = null;
            ProductoCEN productoCEN = null;

            try
            {
                SessionInitializeTransaction();

                pedidoCAD = new PedidoCAD(session);
                pedidoCEN = new PedidoCEN(pedidoCAD);

                clienteCAD = new ClienteCAD(session);
                clienteCEN = new ClienteCEN(clienteCAD);

                productoCAD = new ProductoCAD(session);
                productoCEN = new ProductoCEN(productoCAD);

                PedidoEN pedidoEN = pedidoCEN.ReadOID(p_oid_pedido);
                ClienteEN clienteEN = clienteCEN.ReadOID(p_oid_cliente);

                pedidoEN.TipoTarjeta = p_num_tarjeta;

                // SIMULACIÓN DE PAGO
                // Se validaría que la tarjeta fuera correcta
                //if(p_num_tarjeta == correcta) {
                pedidoEN.FechaPedido = DateTime.Now;
                pedidoEN.FechaEntrega = DateTime.Now.AddDays(7);
                pedidoEN.Estado = Enumerated.Práctica3.EstadoPedidoEnum.reparto;
                clienteEN.Puntos++;

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
