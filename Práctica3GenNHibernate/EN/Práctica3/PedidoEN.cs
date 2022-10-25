
using System;
// Definición clase PedidoEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fechaPedido
 */
private Nullable<DateTime> fechaPedido;



/**
 *	Atributo fechaEntrega
 */
private Nullable<DateTime> fechaEntrega;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo codigoPostal
 */
private int codigoPostal;



/**
 *	Atributo tipoTarjeta
 */
private string tipoTarjeta;



/**
 *	Atributo estado
 */
private Práctica3GenNHibernate.Enumerated.Práctica3.EstadoPedidoEnum estado;



/**
 *	Atributo cliente
 */
private Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido;



/**
 *	Atributo precioTotal
 */
private double precioTotal;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> FechaPedido {
        get { return fechaPedido; } set { fechaPedido = value;  }
}



public virtual Nullable<DateTime> FechaEntrega {
        get { return fechaEntrega; } set { fechaEntrega = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual int CodigoPostal {
        get { return codigoPostal; } set { codigoPostal = value;  }
}



public virtual string TipoTarjeta {
        get { return tipoTarjeta; } set { tipoTarjeta = value;  }
}



public virtual Práctica3GenNHibernate.Enumerated.Práctica3.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual double PrecioTotal {
        get { return precioTotal; } set { precioTotal = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN>();
}



public PedidoEN(int id, Nullable<DateTime> fechaPedido, Nullable<DateTime> fechaEntrega, string direccion, string localidad, string provincia, int codigoPostal, string tipoTarjeta, Práctica3GenNHibernate.Enumerated.Práctica3.EstadoPedidoEnum estado, Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido, double precioTotal
                )
{
        this.init (Id, fechaPedido, fechaEntrega, direccion, localidad, provincia, codigoPostal, tipoTarjeta, estado, cliente, lineaPedido, precioTotal);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.FechaPedido, pedido.FechaEntrega, pedido.Direccion, pedido.Localidad, pedido.Provincia, pedido.CodigoPostal, pedido.TipoTarjeta, pedido.Estado, pedido.Cliente, pedido.LineaPedido, pedido.PrecioTotal);
}

private void init (int id
                   , Nullable<DateTime> fechaPedido, Nullable<DateTime> fechaEntrega, string direccion, string localidad, string provincia, int codigoPostal, string tipoTarjeta, Práctica3GenNHibernate.Enumerated.Práctica3.EstadoPedidoEnum estado, Práctica3GenNHibernate.EN.Práctica3.ClienteEN cliente, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.LineaPedidoEN> lineaPedido, double precioTotal)
{
        this.Id = id;


        this.FechaPedido = fechaPedido;

        this.FechaEntrega = fechaEntrega;

        this.Direccion = direccion;

        this.Localidad = localidad;

        this.Provincia = provincia;

        this.CodigoPostal = codigoPostal;

        this.TipoTarjeta = tipoTarjeta;

        this.Estado = estado;

        this.Cliente = cliente;

        this.LineaPedido = lineaPedido;

        this.PrecioTotal = precioTotal;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
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
