
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
public void AsignarGeneroFav (string p_Cliente_OID, string p_generoFavorito_OID)
{
        Práctica3GenNHibernate.EN.Práctica3.ClienteEN clienteEN = null;
        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), p_Cliente_OID);
                clienteEN.GeneroFavorito = (Práctica3GenNHibernate.EN.Práctica3.GeneroEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.GeneroEN), p_generoFavorito_OID);

                clienteEN.GeneroFavorito.Cliente.Add (clienteEN);



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
