
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


/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CEN.Práctica3_Pedido_realizarPago) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CEN.Práctica3
{
public partial class PedidoCEN
{
public void RealizarPago (int p_oid_pedido, string p_num_tarjeta, string p_tipo_tarjeta, string p_oid_cliente)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CEN.Práctica3_Pedido_realizarPago) ENABLED START*/

        PedidoEN pedidoEN = _IPedidoCAD.ReadOID (p_oid_pedido);
        ClienteEN clienteEN = _IC

        pedidoEN.TipoTarjeta = p_tipo_tarjeta;

        //Se validaría el p_num_tarjeta
        // if(p_num_tarjeta == correcto) {
        pedidoEN.FechaPedido = DateTime.Today;
        pedidoEN.Estado = Enumerated.Práctica3.EstadoPedidoEnum.reparto;
        _IPedidoCAD.Modify (pedidoEN);
        // }

        /*PROTECTED REGION END*/
}
}
}
