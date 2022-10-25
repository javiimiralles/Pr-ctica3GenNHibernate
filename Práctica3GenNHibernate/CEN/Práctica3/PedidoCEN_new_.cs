
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


/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CEN.Práctica3_Pedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CEN.Práctica3
{
public partial class PedidoCEN
{
public int New_ (string p_direccion, string p_localidad, string p_provincia, int p_codigoPostal, string p_tipoTarjeta, string p_cliente)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CEN.Práctica3_Pedido_new__customized) START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Direccion = p_direccion;

        pedidoEN.Localidad = p_localidad;

        pedidoEN.Provincia = p_provincia;

        pedidoEN.CodigoPostal = p_codigoPostal;

        pedidoEN.TipoTarjeta = p_tipoTarjeta;


        if (p_cliente != null) {
                pedidoEN.Cliente = new Práctica3GenNHibernate.EN.Práctica3.ClienteEN ();
                pedidoEN.Cliente.Email = p_cliente;
        }

        //Call to PedidoCAD

        oid = _IPedidoCAD.New_ (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
