
using System;
// Definición clase ComentariosEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class ComentariosEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo cliente
 */
private Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente;



/**
 *	Atributo producto
 */
private Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public ComentariosEN()
{
}



public ComentariosEN(int id, string comentario, Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente, Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto
                     )
{
        this.init (Id, comentario, cliente, producto);
}


public ComentariosEN(ComentariosEN comentarios)
{
        this.init (Id, comentarios.Comentario, comentarios.Cliente, comentarios.Producto);
}

private void init (int id
                   , string comentario, Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente, Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto)
{
        this.Id = id;


        this.Comentario = comentario;

        this.Cliente = cliente;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentariosEN t = obj as ComentariosEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
