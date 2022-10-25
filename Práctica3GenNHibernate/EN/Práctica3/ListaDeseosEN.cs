
using System;
// Definición clase ListaDeseosEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class ListaDeseosEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cliente
 */
private Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente;



/**
 *	Atributo producto
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}





public ListaDeseosEN()
{
        producto = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ProductoEN>();
}



public ListaDeseosEN(int id, Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto
                     )
{
        this.init (Id, cliente, producto);
}


public ListaDeseosEN(ListaDeseosEN listaDeseos)
{
        this.init (Id, listaDeseos.Cliente, listaDeseos.Producto);
}

private void init (int id
                   , Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> producto)
{
        this.Id = id;


        this.Cliente = cliente;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaDeseosEN t = obj as ListaDeseosEN;
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
