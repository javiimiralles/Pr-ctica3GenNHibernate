
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


/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CEN.Práctica3_Producto_aumentarPrecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CEN.Práctica3
{
public partial class ProductoCEN
{
public void AumentarPrecio (int p_producto_oid, double p_aumento)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CEN.Práctica3_Producto_aumentarPrecio) ENABLED START*/

        ProductoEN productoEN = _IProductoCAD.ReadOID (p_producto_oid);

        productoEN.Precio += p_aumento;

        _IProductoCAD.Modify (productoEN);



        /*PROTECTED REGION END*/
}
}
}
