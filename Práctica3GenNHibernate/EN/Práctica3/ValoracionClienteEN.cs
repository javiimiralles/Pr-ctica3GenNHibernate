
using System;
// Definición clase ValoracionClienteEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class ValoracionClienteEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo valoracion
 */
private double valoracion;



/**
 *	Atributo cliente
 */
private Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente;



/**
 *	Atributo producto
 */
private Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto;



/**
 *	Atributo comentario
 */
private string comentario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}





public ValoracionClienteEN()
{
}



public ValoracionClienteEN(int id, double valoracion, Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente, Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto, string comentario
                           )
{
        this.init (Id, valoracion, cliente, producto, comentario);
}


public ValoracionClienteEN(ValoracionClienteEN valoracionCliente)
{
        this.init (Id, valoracionCliente.Valoracion, valoracionCliente.Cliente, valoracionCliente.Producto, valoracionCliente.Comentario);
}

private void init (int id
                   , double valoracion, Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente, Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto, string comentario)
{
        this.Id = id;


        this.Valoracion = valoracion;

        this.Cliente = cliente;

        this.Producto = producto;

        this.Comentario = comentario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionClienteEN t = obj as ValoracionClienteEN;
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
