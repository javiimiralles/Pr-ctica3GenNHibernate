
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



/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CP.Práctica3_ValoracionCliente_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CP.Práctica3
{
public partial class ValoracionClienteCP : BasicCP
{
public Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN New_ (double p_valoracion, string p_cliente, int p_producto)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CP.Práctica3_ValoracionCliente_new_) ENABLED START*/

        IValoracionClienteCAD valoracionClienteCAD = null;
        ValoracionClienteCEN valoracionClienteCEN = null;
        ProductoCAD productoCAD = null;
        ProductoCEN productoCEN = null;

        Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN result = null;


        try
        {
                SessionInitializeTransaction ();
                valoracionClienteCAD = new ValoracionClienteCAD (session);
                valoracionClienteCEN = new  ValoracionClienteCEN (valoracionClienteCAD);

                productoCAD = new ProductoCAD (session);
                productoCEN = new ProductoCEN (productoCAD);




                int oid;
                //Initialized ValoracionClienteEN
                ValoracionClienteEN valoracionClienteEN;
                valoracionClienteEN = new ValoracionClienteEN ();
                valoracionClienteEN.Valoracion = p_valoracion;


                if (p_cliente != null) {
                        valoracionClienteEN.Cliente = new Práctica3GenNHibernate.EN.Práctica3.ClienteEN ();
                        valoracionClienteEN.Cliente.Email = p_cliente;
                }


                if (p_producto != -1) {
                        valoracionClienteEN.Producto = new Práctica3GenNHibernate.EN.Práctica3.ProductoEN ();
                        valoracionClienteEN.Producto.Id = p_producto;
                }

                //Call to ValoracionClienteCAD

                oid = valoracionClienteCAD.New_ (valoracionClienteEN);

                ProductoEN productoEN = productoCEN.ReadOID (valoracionClienteEN.Producto.Id);

                result = valoracionClienteCAD.ReadOIDDefault (oid);

                if (productoEN.ValoracionMedia == 0) {
                        productoEN.ValoracionTotal = valoracionClienteEN.Valoracion;
                        productoEN.NumValoraciones++;
                        productoEN.ValoracionMedia = valoracionClienteEN.Valoracion;
                }
                else{
                        productoEN.NumValoraciones++;
                        productoEN.ValoracionTotal += valoracionClienteEN.Valoracion;
                        productoEN.ValoracionMedia = productoEN.ValoracionTotal / productoEN.NumValoraciones;
                }

                productoEN.ValoracionMedia = Math.Round (productoEN.ValoracionMedia);

                productoCAD.Modify (productoEN);

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
