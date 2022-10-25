
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
 * Clase ListaDeseos:
 *
 */

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial class ListaDeseosCAD : BasicCAD, IListaDeseosCAD
{
public ListaDeseosCAD() : base ()
{
}

public ListaDeseosCAD(ISession sessionAux) : base (sessionAux)
{
}



public ListaDeseosEN ReadOIDDefault (int id
                                     )
{
        ListaDeseosEN listaDeseosEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaDeseosEN = (ListaDeseosEN)session.Get (typeof(ListaDeseosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaDeseosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaDeseosEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaDeseosEN)).List<ListaDeseosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ListaDeseosEN listaDeseos)
{
        try
        {
                SessionInitializeTransaction ();
                ListaDeseosEN listaDeseosEN = (ListaDeseosEN)session.Load (typeof(ListaDeseosEN), listaDeseos.Id);


                session.Update (listaDeseosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ListaDeseosEN listaDeseos)
{
        try
        {
                SessionInitializeTransaction ();
                if (listaDeseos.Cliente != null) {
                        // Argumento OID y no colección.
                        listaDeseos.Cliente = (Práctica3GenNHibernate.EN.Práctica3.ClienteEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.ClienteEN), listaDeseos.Cliente.Email);

                        listaDeseos.Cliente.ListaDeseos
                                = listaDeseos;
                }

                session.Save (listaDeseos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseos.Id;
}

public void Modify (ListaDeseosEN listaDeseos)
{
        try
        {
                SessionInitializeTransaction ();
                ListaDeseosEN listaDeseosEN = (ListaDeseosEN)session.Load (typeof(ListaDeseosEN), listaDeseos.Id);
                session.Update (listaDeseosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
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
                ListaDeseosEN listaDeseosEN = (ListaDeseosEN)session.Load (typeof(ListaDeseosEN), id);
                session.Delete (listaDeseosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ListaDeseosEN
public ListaDeseosEN ReadOID (int id
                              )
{
        ListaDeseosEN listaDeseosEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaDeseosEN = (ListaDeseosEN)session.Get (typeof(ListaDeseosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ListaDeseosEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ListaDeseosEN>();
                else
                        result = session.CreateCriteria (typeof(ListaDeseosEN)).List<ListaDeseosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
