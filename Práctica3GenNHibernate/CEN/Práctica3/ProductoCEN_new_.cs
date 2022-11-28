
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


/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CEN.Práctica3_Producto_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CEN.Práctica3
{
public partial class ProductoCEN
{
public int New_ (string p_nombre, string p_descripcion, double p_precio, int p_stock, string p_imagen)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CEN.Práctica3_Producto_new__customized) ENABLED START*/

        ProductoEN productoEN = null;

        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Nombre = p_nombre;

        productoEN.Descripcion = p_descripcion;

        productoEN.Precio = p_precio;

        productoEN.Stock = p_stock;

        productoEN.Imagen = p_imagen;

        productoEN.ValoracionMedia = 0;

        //Call to ProductoCAD

        oid = _IProductoCAD.New_ (productoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
