
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
 * Clase Genero:
 *
 */

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial class GeneroCAD : BasicCAD, IGeneroCAD
{
public GeneroCAD() : base ()
{
}

public GeneroCAD(ISession sessionAux) : base (sessionAux)
{
}



public GeneroEN ReadOIDDefault (int id
                                )
{
        GeneroEN generoEN = null;

        try
        {
                SessionInitializeTransaction ();
                generoEN = (GeneroEN)session.Get (typeof(GeneroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return generoEN;
}

public System.Collections.Generic.IList<GeneroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GeneroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GeneroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GeneroEN>();
                        else
                                result = session.CreateCriteria (typeof(GeneroEN)).List<GeneroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (GeneroEN genero)
{
        try
        {
                SessionInitializeTransaction ();
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), genero.Id);

                generoEN.Nombre = genero.Nombre;



                session.Update (generoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (GeneroEN genero)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (genero);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return genero.Id;
}

public void Modify (GeneroEN genero)
{
        try
        {
                SessionInitializeTransaction ();
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), genero.Id);

                generoEN.Nombre = genero.Nombre;

                session.Update (generoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
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
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), id);
                session.Delete (generoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: GeneroEN
public GeneroEN ReadOID (int id
                         )
{
        GeneroEN generoEN = null;

        try
        {
                SessionInitializeTransaction ();
                generoEN = (GeneroEN)session.Get (typeof(GeneroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return generoEN;
}

public System.Collections.Generic.IList<GeneroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GeneroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GeneroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GeneroEN>();
                else
                        result = session.CreateCriteria (typeof(GeneroEN)).List<GeneroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Práctica3GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Práctica3GenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
