
using System;
// Definición clase GeneroEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class GeneroEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo producto
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto;



/**
 *	Atributo cliente
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> cliente;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> Cliente {
        get { return cliente; } set { cliente = value;  }
}





public GeneroEN()
{
        producto = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ProductoEN>();
        cliente = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ClienteEN>();
}



public GeneroEN(string nombre, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> cliente
                )
{
        this.init (Nombre, producto, cliente);
}


public GeneroEN(GeneroEN genero)
{
        this.init (Nombre, genero.Producto, genero.Cliente);
}

private void init (string nombre
                   , System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> cliente)
{
        this.Nombre = nombre;


        this.Producto = producto;

        this.Cliente = cliente;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GeneroEN t = obj as GeneroEN;
        if (t == null)
                return false;
        if (Nombre.Equals (t.Nombre))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nombre.GetHashCode ();
        return hash;
}
}
}
