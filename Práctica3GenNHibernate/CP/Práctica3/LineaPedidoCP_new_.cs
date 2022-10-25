
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;
using Práctica3GenNHibernate.CEN.Práctica3;



/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CP.Práctica3_lineaPedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CP.Práctica3
{
public partial class LineaPedidoCP : BasicCP
{
public Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN New_ (int p_producto, int p_pedido, int p_cantidad)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CP.Práctica3_lineaPedido_new_) ENABLED START*/

        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;
        PedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;

        Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new  LineaPedidoCEN (lineaPedidoCAD);

                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new PedidoCEN (pedidoCAD);


                int oid;
                //Initialized LineaPedidoEN
                LineaPedidoEN lineaPedidoEN;
                lineaPedidoEN = new LineaPedidoEN ();

                if (p_producto != -1) {
                        lineaPedidoEN.Producto = new Práctica3GenNHibernate.EN.Práctica3.ProductoEN ();
                        lineaPedidoEN.Producto.Id = p_producto;
                }


                if (p_pedido != -1) {
                        lineaPedidoEN.Pedido = new Práctica3GenNHibernate.EN.Práctica3.PedidoEN ();
                        lineaPedidoEN.Pedido.Id = p_pedido;
                }

                //Call to LineaPedidoCAD

                oid = lineaPedidoCAD.New_ (lineaPedidoEN);

                PedidoEN pedidoEN = pedidoCEN.ReadOID (lineaPedidoEN.Id);

                result = lineaPedidoCAD.ReadOIDDefault (oid);
                pedidoEN.PrecioTotal += lineaPedidoEN.Cantidad * lineaPedidoEN.Producto.Precio;

                pedidoCAD.ModifyDefault (pedidoEN);

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
