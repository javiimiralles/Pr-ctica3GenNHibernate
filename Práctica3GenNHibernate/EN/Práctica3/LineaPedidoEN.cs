
using System;
// Definición clase LineaPedidoEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class LineaPedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo producto
 */
private Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto;



/**
 *	Atributo pedido
 */
private Práctica3GenNHibernate.EN.Práctica3.PedidoEN pedido;



/**
 *	Atributo cantidad
 */
private int cantidad;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto, Práctica3GenNHibernate.EN.Práctica3.PedidoEN pedido, int cantidad
                     )
{
        this.init (Id, producto, pedido, cantidad);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (Id, lineaPedido.Producto, lineaPedido.Pedido, lineaPedido.Cantidad);
}

private void init (int id
                   , Práctica3GenNHibernate.EN.Práctica3.ProductoEN producto, Práctica3GenNHibernate.EN.Práctica3.PedidoEN pedido, int cantidad)
{
        this.Id = id;


        this.Producto = producto;

        this.Pedido = pedido;

        this.Cantidad = cantidad;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
