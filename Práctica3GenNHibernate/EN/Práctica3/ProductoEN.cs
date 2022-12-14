
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
private Práctica3GenNHibernate.EN.Práctica3.GeneroEN genero;



/**
 *	Atributo valoracionMedia
 */
private double valoracionMedia;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido;



/**
 *	Atributo valoracionCliente
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente;



/**
 *	Atributo numValoraciones
 */
private int numValoraciones;



/**
 *	Atributo valoracionTotal
 */
private double valoracionTotal;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo cliente
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> cliente;






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



public virtual Práctica3GenNHibernate.EN.Práctica3.GeneroEN Genero {
        get { return genero; } set { genero = value;  }
}



public virtual double ValoracionMedia {
        get { return valoracionMedia; } set { valoracionMedia = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> ValoracionCliente {
        get { return valoracionCliente; } set { valoracionCliente = value;  }
}



public virtual int NumValoraciones {
        get { return numValoraciones; } set { numValoraciones = value;  }
}



public virtual double ValoracionTotal {
        get { return valoracionTotal; } set { valoracionTotal = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> Cliente {
        get { return cliente; } set { cliente = value;  }
}





public ProductoEN()
{
        lineaPedido = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN>();
        valoracionCliente = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN>();
        cliente = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ClienteEN>();
}



public ProductoEN(int id, string nombre, string descripcion, double precio, int stock, Práctica3GenNHibernate.EN.Práctica3.GeneroEN genero, double valoracionMedia, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente, int numValoraciones, double valoracionTotal, string imagen, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> cliente
                  )
{
        this.init (Id, nombre, descripcion, precio, stock, genero, valoracionMedia, lineaPedido, valoracionCliente, numValoraciones, valoracionTotal, imagen, cliente);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Id, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock, producto.Genero, producto.ValoracionMedia, producto.LineaPedido, producto.ValoracionCliente, producto.NumValoraciones, producto.ValoracionTotal, producto.Imagen, producto.Cliente);
}

private void init (int id
                   , string nombre, string descripcion, double precio, int stock, Práctica3GenNHibernate.EN.Práctica3.GeneroEN genero, double valoracionMedia, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente, int numValoraciones, double valoracionTotal, string imagen, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> cliente)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Precio = precio;

        this.Stock = stock;

        this.Genero = genero;

        this.ValoracionMedia = valoracionMedia;

        this.LineaPedido = lineaPedido;

        this.ValoracionCliente = valoracionCliente;

        this.NumValoraciones = numValoraciones;

        this.ValoracionTotal = valoracionTotal;

        this.Imagen = imagen;

        this.Cliente = cliente;
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
