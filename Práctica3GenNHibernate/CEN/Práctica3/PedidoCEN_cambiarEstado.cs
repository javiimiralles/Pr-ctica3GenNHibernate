
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Práctica3GenNHibernate.Exceptions;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;


/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CEN.Práctica3_Pedido_cambiarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CEN.Práctica3
{
public partial class PedidoCEN
{
public void CambiarEstado (int p_pedido_oid)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CEN.Práctica3_Pedido_cambiarEstado) ENABLED START*/

        PedidoEN pedidoEN = _IPedidoCAD.ReadOID (p_pedido_oid);

        if (pedidoEN.Estado.Equals (Enumerated.Práctica3.EstadoPedidoEnum.cesta)) {
                pedidoEN.Estado = Enumerated.Práctica3.EstadoPedidoEnum.reparto;
                pedidoEN.FechaEntrega = DateTime.Today;
        }
        else if (pedidoEN.Estado.Equals (Enumerated.Práctica3.EstadoPedidoEnum.reparto)) {
                pedidoEN.Estado = Enumerated.Práctica3.EstadoPedidoEnum.entregado;
                pedidoEN.FechaEntrega = DateTime.Today;
        }
        else
                throw new ModelException ("El pedido ya ha sido entregado.");

        _IPedidoCAD.Modify (pedidoEN);

        /*PROTECTED REGION END*/
}
}
}
