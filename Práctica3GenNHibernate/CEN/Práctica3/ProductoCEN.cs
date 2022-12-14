

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Práctica3GenNHibernate.Exceptions;

using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;


namespace Práctica3GenNHibernate.CEN.Práctica3
{
/*
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoCAD _IProductoCAD;

public ProductoCEN()
{
        this._IProductoCAD = new ProductoCAD ();
}

public ProductoCEN(IProductoCAD _IProductoCAD)
{
        this._IProductoCAD = _IProductoCAD;
}

public IProductoCAD get_IProductoCAD ()
{
        return this._IProductoCAD;
}

public void Modify (int p_Producto_OID, string p_nombre, string p_descripcion, double p_precio, int p_stock, double p_valoracionMedia, int p_numValoraciones, double p_valoracionTotal, string p_imagen)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Id = p_Producto_OID;
        productoEN.Nombre = p_nombre;
        productoEN.Descripcion = p_descripcion;
        productoEN.Precio = p_precio;
        productoEN.Stock = p_stock;
        productoEN.ValoracionMedia = p_valoracionMedia;
        productoEN.NumValoraciones = p_numValoraciones;
        productoEN.ValoracionTotal = p_valoracionTotal;
        productoEN.Imagen = p_imagen;
        //Call to ProductoCAD

        _IProductoCAD.Modify (productoEN);
}

public void Destroy (int id
                     )
{
        _IProductoCAD.Destroy (id);
}

public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoCAD.ReadOID (id);
        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> FiltrarPorValoracion ()
{
        return _IProductoCAD.FiltrarPorValoracion ();
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> ObtenerProductosPorGeneroFav (string p_oid_cliente)
{
        return _IProductoCAD.ObtenerProductosPorGeneroFav (p_oid_cliente);
}
public void AsignarGenero (int p_Producto_OID, string p_genero_OID)
{
        //Call to ProductoCAD

        _IProductoCAD.AsignarGenero (p_Producto_OID, p_genero_OID);
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> DameProductosPorGenero (string p_genero)
{
        return _IProductoCAD.DameProductosPorGenero (p_genero);
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> DameListaFavoritosCliente (string p_oid_cliente)
{
        return _IProductoCAD.DameListaFavoritosCliente (p_oid_cliente);
}
}
}
