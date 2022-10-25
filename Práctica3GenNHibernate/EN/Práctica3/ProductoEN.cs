
using System;
// Definición clase ProductoEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class ProductoEN
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
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo genero
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.GeneroEN> genero;



/**
 *	Atributo valoracionMedia
 */
private double valoracionMedia;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN> comentarios;



/**
 *	Atributo listaDeseos
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN> listaDeseos;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido;



/**
 *	Atributo valoracionCliente
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.GeneroEN> Genero {
        get { return genero; } set { genero = value;  }
}



public virtual double ValoracionMedia {
        get { return valoracionMedia; } set { valoracionMedia = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN> ListaDeseos {
        get { return listaDeseos; } set { listaDeseos = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> ValoracionCliente {
        get { return valoracionCliente; } set { valoracionCliente = value;  }
}





public ProductoEN()
{
        genero = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.GeneroEN>();
        comentarios = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN>();
        listaDeseos = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN>();
        lineaPedido = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN>();
        valoracionCliente = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN>();
}



public ProductoEN(int id, string nombre, string descripcion, double precio, int stock, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.GeneroEN> genero, double valoracionMedia, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN> comentarios, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN> listaDeseos, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente
                  )
{
        this.init (Id, nombre, descripcion, precio, stock, genero, valoracionMedia, comentarios, listaDeseos, lineaPedido, valoracionCliente);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Id, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock, producto.Genero, producto.ValoracionMedia, producto.Comentarios, producto.ListaDeseos, producto.LineaPedido, producto.ValoracionCliente);
}

private void init (int id
                   , string nombre, string descripcion, double precio, int stock, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.GeneroEN> genero, double valoracionMedia, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN> comentarios, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN> listaDeseos, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Precio = precio;

        this.Stock = stock;

        this.Genero = genero;

        this.ValoracionMedia = valoracionMedia;

        this.Comentarios = comentarios;

        this.ListaDeseos = listaDeseos;

        this.LineaPedido = lineaPedido;

        this.ValoracionCliente = valoracionCliente;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
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
