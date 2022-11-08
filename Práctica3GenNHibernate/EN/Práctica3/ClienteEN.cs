
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
 *	Atributo teléfono
 */
private int teléfono;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> pedido;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN> comentarios;



/**
 *	Atributo listaDeseos
 */
private Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN listaDeseos;



/**
 *	Atributo valoracionCliente
 */
private System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente;



/**
 *	Atributo puntos
 */
private int puntos;



/**
 *	Atributo generoFavorito
 */
private Práctica3GenNHibernate.EN.Práctica3.GeneroEN generoFavorito;






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



public virtual int Teléfono {
        get { return teléfono; } set { teléfono = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN ListaDeseos {
        get { return listaDeseos; } set { listaDeseos = value;  }
}



public virtual System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> ValoracionCliente {
        get { return valoracionCliente; } set { valoracionCliente = value;  }
}



public virtual int Puntos {
        get { return puntos; } set { puntos = value;  }
}



public virtual Práctica3GenNHibernate.EN.Práctica3.GeneroEN GeneroFavorito {
        get { return generoFavorito; } set { generoFavorito = value;  }
}





public ClienteEN()
{
        pedido = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.PedidoEN>();
        comentarios = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN>();
        valoracionCliente = new System.Collections.Generic.List<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN>();
}



public ClienteEN(string email, string nombre, string apellidos, string nombreUsuario, int teléfono, String pass, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> pedido, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN> comentarios, Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN listaDeseos, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente, int puntos, Práctica3GenNHibernate.EN.Práctica3.GeneroEN generoFavorito
                 )
{
        this.init (Email, nombre, apellidos, nombreUsuario, teléfono, pass, pedido, comentarios, listaDeseos, valoracionCliente, puntos, generoFavorito);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (Email, cliente.Nombre, cliente.Apellidos, cliente.NombreUsuario, cliente.Teléfono, cliente.Pass, cliente.Pedido, cliente.Comentarios, cliente.ListaDeseos, cliente.ValoracionCliente, cliente.Puntos, cliente.GeneroFavorito);
}

private void init (string email
                   , string nombre, string apellidos, string nombreUsuario, int teléfono, String pass, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> pedido, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ComentariosEN> comentarios, Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN listaDeseos, System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ValoracionClienteEN> valoracionCliente, int puntos, Práctica3GenNHibernate.EN.Práctica3.GeneroEN generoFavorito)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.NombreUsuario = nombreUsuario;

        this.Teléfono = teléfono;

        this.Pass = pass;

        this.Pedido = pedido;

        this.Comentarios = comentarios;

        this.ListaDeseos = listaDeseos;

        this.ValoracionCliente = valoracionCliente;

        this.Puntos = puntos;

        this.GeneroFavorito = generoFavorito;
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
