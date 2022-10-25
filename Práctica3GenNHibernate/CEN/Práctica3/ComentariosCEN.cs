

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
 *      Definition of the class ComentariosCEN
 *
 */
public partial class ComentariosCEN
{
private IComentariosCAD _IComentariosCAD;

public ComentariosCEN()
{
        this._IComentariosCAD = new ComentariosCAD ();
}

public ComentariosCEN(IComentariosCAD _IComentariosCAD)
{
        this._IComentariosCAD = _IComentariosCAD;
}

public IComentariosCAD get_IComentariosCAD ()
{
        return this._IComentariosCAD;
}

public int New_ (string p_comentario, string p_cliente, int p_producto)
{
        ComentariosEN comentariosEN = null;
        int oid;

        //Initialized ComentariosEN
        comentariosEN = new ComentariosEN ();
        comentariosEN.Comentario = p_comentario;


        if (p_cliente != null) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                comentariosEN.Cliente = new Práctica3GenNHibernate.EN.Práctica3.ClienteEN ();
                comentariosEN.Cliente.Email = p_cliente;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                comentariosEN.Producto = new Práctica3GenNHibernate.EN.Práctica3.ProductoEN ();
                comentariosEN.Producto.Id = p_producto;
        }

        //Call to ComentariosCAD

        oid = _IComentariosCAD.New_ (comentariosEN);
        return oid;
}

public void Modify (int p_Comentarios_OID, string p_comentario)
{
        ComentariosEN comentariosEN = null;

        //Initialized ComentariosEN
        comentariosEN = new ComentariosEN ();
        comentariosEN.Id = p_Comentarios_OID;
        comentariosEN.Comentario = p_comentario;
        //Call to ComentariosCAD

        _IComentariosCAD.Modify (comentariosEN);
}

public void Destroy (int id
                     )
{
        _IComentariosCAD.Destroy (id);
}

public ComentariosEN ReadOID (int id
                              )
{
        ComentariosEN comentariosEN = null;

        comentariosEN = _IComentariosCAD.ReadOID (id);
        return comentariosEN;
}

public System.Collections.Generic.IList<ComentariosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentariosEN> list = null;

        list = _IComentariosCAD.ReadAll (first, size);
        return list;
}
}
}
