
using System;
// Definición clase ClienteEN
namespace Práctica3GenNHibernate.EN.Práctica3
{
public partial class ClienteEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo nombreUsuario
 */
private string nombreUsuario;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> pedido;



/**
 *	Atributo valoracionCliente
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente;



/**
 *	Atributo puntos
 */
private int puntos;



/**
 *	Atributo productoFavorito
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> productoFavorito;



/**
 *	Atributo generoFav
 */
private string generoFav;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string NombreUsuario {
        get { return nombreUsuario; } set { nombreUsuario = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> ValoracionCliente {
        get { return valoracionCliente; } set { valoracionCliente = value;  }
}



public virtual int Puntos {
        get { return puntos; } set { puntos = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> ProductoFavorito {
        get { return productoFavorito; } set { productoFavorito = value;  }
}



public virtual string GeneroFav {
        get { return generoFav; } set { generoFav = value;  }
}





public ClienteEN()
{
        pedido = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.PedidoEN>();
        valoracionCliente = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN>();
        productoFavorito = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ProductoEN>();
}



public ClienteEN(string email, string nombre, string apellidos, string nombreUsuario, int telefono, String pass, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> pedido, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente, int puntos, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> productoFavorito, string generoFav
                 )
{
        this.init (Email, nombre, apellidos, nombreUsuario, telefono, pass, pedido, valoracionCliente, puntos, productoFavorito, generoFav);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (Email, cliente.Nombre, cliente.Apellidos, cliente.NombreUsuario, cliente.Telefono, cliente.Pass, cliente.Pedido, cliente.ValoracionCliente, cliente.Puntos, cliente.ProductoFavorito, cliente.GeneroFav);
}

private void init (string email
                   , string nombre, string apellidos, string nombreUsuario, int telefono, String pass, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> pedido, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente, int puntos, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> productoFavorito, string generoFav)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.NombreUsuario = nombreUsuario;

        this.Telefono = telefono;

        this.Pass = pass;

        this.Pedido = pedido;

        this.ValoracionCliente = valoracionCliente;

        this.Puntos = puntos;

        this.ProductoFavorito = productoFavorito;

        this.GeneroFav = generoFav;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ClienteEN t = obj as ClienteEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
