
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
 * Clase Comentarios:
 *
 */

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial class ComentariosCAD : BasicCAD, IComentariosCAD
{
public ComentariosCAD() : base ()
{
}

public ComentariosCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComentariosEN ReadOIDDefault (int id
                                     )
{
        ComentariosEN comentariosEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentariosEN = (ComentariosEN)session.Get (typeof(ComentariosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentariosEN;
}

public System.Collections.Generic.IList<ComentariosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentariosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentariosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentariosEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentariosEN)).List<ComentariosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentariosEN comentarios)
{
        try
        {
                SessionInitializeTransaction ();
                ComentariosEN comentariosEN = (ComentariosEN)session.Load (typeof(ComentariosEN), comentarios.Id);

                comentariosEN.Comentario = comentarios.Comentario;



                session.Update (comentariosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentariosEN comentarios)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentarios.Cliente != null) {
                        // Argumento OID y no colección.
                        comentarios.Cliente = (Práctica3GenNHibernate.EN.Práctica3.ClienteEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.ClienteEN), comentarios.Cliente.Email);

                        comentarios.Cliente.Comentarios
                        .Add (comentarios);
                }
                if (comentarios.Producto != null) {
                        // Argumento OID y no colección.
                        comentarios.Producto = (Práctica3GenNHibernate.EN.Práctica3.ProductoEN)session.Load (typeof(Práctica3GenNHibernate.EN.Práctica3.ProductoEN), comentarios.Producto.Id);

                        comentarios.Producto.Comentarios
                        .Add (comentarios);
                }

                session.Save (comentarios);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarios.Id;
}

public void Modify (ComentariosEN comentarios)
{
        try
        {
                SessionInitializeTransaction ();
                ComentariosEN comentariosEN = (ComentariosEN)session.Load (typeof(ComentariosEN), comentarios.Id);

                comentariosEN.Comentario = comentarios.Comentario;

                session.Update (comentariosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
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
                ComentariosEN comentariosEN = (ComentariosEN)session.Load (typeof(ComentariosEN), id);
                session.Delete (comentariosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComentariosEN
public ComentariosEN ReadOID (int id
                              )
{
        ComentariosEN comentariosEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentariosEN = (ComentariosEN)session.Get (typeof(ComentariosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentariosEN;
}

public System.Collections.Generic.IList<ComentariosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentariosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentariosEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentariosEN>();
                else
                        result = session.CreateCriteria (typeof(ComentariosEN)).List<ComentariosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
