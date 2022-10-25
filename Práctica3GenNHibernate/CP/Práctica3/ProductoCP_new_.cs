
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



/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CP.Práctica3_Producto_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CP.Práctica3
{
public partial class ProductoCP : BasicCP
{
public Práctica3GenNHibernate.EN.Práctica3.ProductoEN New_ (string p_nombre, string p_descripcion, float p_precio, int p_stock, System.Collections.Generic.IList<int> p_genero)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CP.Práctica3_Producto_new_) ENABLED START*/

        IProductoCAD productoCAD = null;
        ProductoCEN productoCEN = null;
        ValoracionClienteCAD valCAD = null;
        ValoracionClienteCEN valCEN = null;

        Práctica3GenNHibernate.EN.Práctica3.ProductoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                productoCAD = new ProductoCAD (session);
                productoCEN = new  ProductoCEN (productoCAD);

                valCAD = new ValoracionClienteCAD(session);
                valCEN = new ValoracionClienteCEN(valCAD);


                int oid;
                //Initialized ProductoEN
                ProductoEN productoEN;
                productoEN = new ProductoEN ();
                productoEN.Nombre = p_nombre;

                productoEN.Descripcion = p_descripcion;

                productoEN.Precio = p_precio;

                productoEN.Stock = p_stock;


                productoCAD.AsignarGenero(productoEN.Id, p_genero);

                //Call to ProductoCAD

                oid = productoCAD.New_ (productoEN);

                ValoracionClienteEN valEN = valCEN.ReadOID(productoEN.Id);

                result = productoCAD.ReadOIDDefault (oid);



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
