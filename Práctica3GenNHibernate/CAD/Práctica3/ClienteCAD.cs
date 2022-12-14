
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
 * Clase Cliente:
 *
 */

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial class ClienteCAD : BasicCAD, IClienteCAD
{
public ClienteCAD() : base ()
{
}

public ClienteCAD(ISession sessionAux) : base (sessionAux)
{
}



public ClienteEN ReadOIDDefault (string email
                                 )
{
        ClienteEN clienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ClienteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ClienteEN>();
                        else
                                result = session.CreateCriteria (typeof(ClienteEN)).List<ClienteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), cliente.Email);

                clienteEN.Nombre = cliente.Nombre;


                clienteEN.Apellidos = cliente.Apellidos;


                clienteEN.NombreUsuario = cliente.NombreUsuario;


                clienteEN.Teléfono = cliente.Teléfono;


                clienteEN.Pass = cliente.Pass;




                clienteEN.Puntos = cliente.Puntos;



                clienteEN.GeneroFav = cliente.GeneroFav;

                session.Update (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (cliente);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cliente.Email;
}

public void Modify (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), cliente.Email);

                clienteEN.Nombre = cliente.Nombre;


                clienteEN.Apellidos = cliente.Apellidos;


                clienteEN.NombreUsuario = cliente.NombreUsuario;


                clienteEN.Teléfono = cliente.Teléfono;


                clienteEN.Pass = cliente.Pass;


                clienteEN.Puntos = cliente.Puntos;


                clienteEN.GeneroFav = cliente.GeneroFav;

                session.Update (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), email);
                session.Delete (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ClienteEN
public ClienteEN ReadOID (string email
                          )
{
        ClienteEN clienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ClienteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ClienteEN>();
                else
                        result = session.CreateCriteria (typeof(ClienteEN)).List<ClienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> ObtenerClientesSinPuntos ()
{
        System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ClienteEN self where FROM ClienteEN as cli WHERE cli.Puntos = 0 ORDER BY cli.Nombre ASC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ClienteENobtenerClientesSinPuntosHQL");

                result = query.List<Práctica3GenNHibernate.EN.Práctica3.ClienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> DameClientesPorEmail (string p_email)
{
        System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ClienteEN self where FROM ClienteEN as cli WHERE cli.Email = :p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ClienteENdameClientesPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<Práctica3GenNHibernate.EN.Práctica3.ClienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AgregarProductoFavorito (string p_Cliente_OID, System.Collections.Generic.IList<int> p_productoFavorito_OIDs)
{
        Práctica3GenNHibernate.EN.Práctica3.ClienteEN clienteEN = null;
        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), p_Cliente_OID);
                Práctica3GenNHibernate.EN.Práctica3.ProductoEN productoFavoritoENAux = null;
                if (clienteEN.ProductoFavorito == null) {
                        clienteEN.ProductoFavorito = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ProductoEN>();
                }

                foreach (int item in p_productoFavorito_OIDs) {
                        productoFavoritoENAux = new Práctica3GenNHibernate.EN.Práctica3.ProductoEN ();
                        productoFavoritoENAux = (Práctica3GenNHibernate.EN.Práctica3.ProductoEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.ProductoEN), item);
                        productoFavoritoENAux.Cliente.Add (clienteEN);

                        clienteEN.ProductoFavorito.Add (productoFavoritoENAux);
                }


                session.Update (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarProductoFavorito (string p_Cliente_OID, System.Collections.Generic.IList<int> p_productoFavorito_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                Práctica3GenNHibernate.EN.Práctica3.ClienteEN clienteEN = null;
                clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), p_Cliente_OID);

                Práctica3GenNHibernate.EN.Práctica3.ProductoEN productoFavoritoENAux = null;
                if (clienteEN.ProductoFavorito != null) {
                        foreach (int item in p_productoFavorito_OIDs) {
                                productoFavoritoENAux = (Práctica3GenNHibernate.EN.Práctica3.ProductoEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.ProductoEN), item);
                                if (clienteEN.ProductoFavorito.Contains (productoFavoritoENAux) == true) {
                                        clienteEN.ProductoFavorito.Remove (productoFavoritoENAux);
                                        productoFavoritoENAux.Cliente.Remove (clienteEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_productoFavorito_OIDs you are trying to unrelationer, doesn't exist in ClienteEN");
                        }
                }

                session.Update (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
