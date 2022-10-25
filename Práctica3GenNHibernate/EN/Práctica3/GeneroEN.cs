
using System;
// Definición clase GeneroEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class GeneroEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo producto
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}





public GeneroEN()
{
        producto = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ProductoEN>();
}



public GeneroEN(int id, string nombre, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto
                )
{
        this.init (Id, nombre, producto);
}


public GeneroEN(GeneroEN genero)
{
        this.init (Id, genero.Nombre, genero.Producto);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GeneroEN t = obj as GeneroEN;
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
