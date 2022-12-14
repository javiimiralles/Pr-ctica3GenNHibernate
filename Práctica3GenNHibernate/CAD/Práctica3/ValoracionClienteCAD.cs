
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
 * Clase ValoracionCliente:
 *
 */

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial class ValoracionClienteCAD : BasicCAD, IValoracionClienteCAD
{
public ValoracionClienteCAD() : base ()
{
}

public ValoracionClienteCAD(ISession sessionAux) : base (sessionAux)
{
}



public ValoracionClienteEN ReadOIDDefault (int id
                                           )
{
        ValoracionClienteEN valoracionClienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionClienteEN = (ValoracionClienteEN)session.Get (typeof(ValoracionClienteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionClienteEN;
}

public System.Collections.Generic.IList<ValoracionClienteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionClienteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionClienteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionClienteEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionClienteEN)).List<ValoracionClienteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionClienteCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionClienteEN valoracionCliente)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionClienteEN valoracionClienteEN = (ValoracionClienteEN)session.Load (typeof(ValoracionClienteEN), valoracionCliente.Id);

                valoracionClienteEN.Valoracion = valoracionCliente.Valoracion;




                valoracionClienteEN.Comentario = valoracionCliente.Comentario;

                session.Update (valoracionClienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ValoracionClienteEN valoracionCliente)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracionCliente.Cliente != null) {
                        // Argumento OID y no colección.
                        valoracionCliente.Cliente = (Práctica3GenNHibernate.EN.Práctica3.ClienteEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.ClienteEN), valoracionCliente.Cliente.Email);

                        valoracionCliente.Cliente.ValoracionCliente
                        .Add (valoracionCliente);
                }
                if (valoracionCliente.Producto != null) {
                        // Argumento OID y no colección.
                        valoracionCliente.Producto = (Práctica3GenNHibernate.EN.Práctica3.ProductoEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.ProductoEN), valoracionCliente.Producto.Id);

                        valoracionCliente.Producto.ValoracionCliente
                        .Add (valoracionCliente);
                }

                session.Save (valoracionCliente);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionCliente.Id;
}

public void Modify (ValoracionClienteEN valoracionCliente)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionClienteEN valoracionClienteEN = (ValoracionClienteEN)session.Load (typeof(ValoracionClienteEN), valoracionCliente.Id);

                valoracionClienteEN.Valoracion = valoracionCliente.Valoracion;


                valoracionClienteEN.Comentario = valoracionCliente.Comentario;

                session.Update (valoracionClienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionClienteCAD.", ex);
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
                ValoracionClienteEN valoracionClienteEN = (ValoracionClienteEN)session.Load (typeof(ValoracionClienteEN), id);
                session.Delete (valoracionClienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ValoracionClienteEN
public ValoracionClienteEN ReadOID (int id
                                    )
{
        ValoracionClienteEN valoracionClienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionClienteEN = (ValoracionClienteEN)session.Get (typeof(ValoracionClienteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionClienteEN;
}

public System.Collections.Generic.IList<ValoracionClienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionClienteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ValoracionClienteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ValoracionClienteEN>();
                else
                        result = session.CreateCriteria (typeof(ValoracionClienteEN)).List<ValoracionClienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
