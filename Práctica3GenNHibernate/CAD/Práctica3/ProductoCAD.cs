
using System;
using System.Text;
using Práctica3GenNHibernate.CEN.Práctica3;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.Exceptions;


/*
 * Clase Producto:
 *
 */

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial class ProductoCAD : BasicCAD, IProductoCAD
{
public ProductoCAD() : base ()
{
}

public ProductoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProductoEN ReadOIDDefault (int id
                                  )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductoEN)).List<ProductoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), producto.Id);

                productoEN.Nombre = producto.Nombre;


                productoEN.Descripcion = producto.Descripcion;


                productoEN.Precio = producto.Precio;


                productoEN.Stock = producto.Stock;



                productoEN.ValoracionMedia = producto.ValoracionMedia;






                productoEN.NumValoraciones = producto.NumValoraciones;


                productoEN.ValoracionTotal = producto.ValoracionTotal;


                productoEN.Imagen = producto.Imagen;

                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (producto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return producto.Id;
}

public void Modify (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), producto.Id);

                productoEN.Nombre = producto.Nombre;


                productoEN.Descripcion = producto.Descripcion;


                productoEN.Precio = producto.Precio;


                productoEN.Stock = producto.Stock;


                productoEN.ValoracionMedia = producto.ValoracionMedia;


                productoEN.NumValoraciones = producto.NumValoraciones;


                productoEN.ValoracionTotal = producto.ValoracionTotal;


                productoEN.Imagen = producto.Imagen;

                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), id);
                session.Delete (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ProductoEN
public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoEN)).List<ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> FiltrarPorValoracion ()
{
        System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where FROM ProductoEN ORDER BY valoracionMedia DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENfiltrarPorValoracionHQL");

                result = query.List<Práctica3GenNHibernate.EN.Práctica3.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> ObtenerProductosPorGeneroFav (string p_oid_cliente)
{
        System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where SELECT prod FROM ClienteEN as cli, ProductoEN as prod WHERE cli.GeneroFavorito = prod.Genero AND cli.Email = :p_oid_cliente";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENobtenerProductosPorGeneroFavHQL");
                query.SetParameter ("p_oid_cliente", p_oid_cliente);

                result = query.List<Práctica3GenNHibernate.EN.Práctica3.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AsignarGenero (int p_Producto_OID, string p_genero_OID)
{
        Práctica3GenNHibernate.EN.Práctica3.ProductoEN productoEN = null;
        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Load (typeof(ProductoEN), p_Producto_OID);
                productoEN.Genero = (Práctica3GenNHibernate.EN.Práctica3.GeneroEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.GeneroEN), p_genero_OID);

                productoEN.Genero.Producto.Add (productoEN);



                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> DameProductosPorGenero (string p_genero)
{
        System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where SELECT prod FROM ProductoEN as prod WHERE prod.Genero.Nombre = :p_genero";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENdameProductosPorGeneroHQL");
                query.SetParameter ("p_genero", p_genero);

                result = query.List<Práctica3GenNHibernate.EN.Práctica3.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
