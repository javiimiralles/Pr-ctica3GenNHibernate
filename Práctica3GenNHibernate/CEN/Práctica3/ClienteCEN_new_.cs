
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Práctica3GenNHibernate.Exceptions;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;


/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CEN.Práctica3_Cliente_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CEN.Práctica3
{
public partial class ClienteCEN
{
public string New_ (string p_email, string p_nombre, string p_apellidos, string p_nombreUsuario, int p_teléfono, String p_pass, string p_genero_fav)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CEN.Práctica3_Cliente_new__customized) ENABLED START*/

        ClienteEN clienteEN = null;

        string oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Email = p_email;

        clienteEN.Nombre = p_nombre;

        clienteEN.Apellidos = p_apellidos;

        clienteEN.NombreUsuario = p_nombreUsuario;

        clienteEN.Teléfono = p_teléfono;

        clienteEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        clienteEN.Puntos = 0;

        clienteEN.GeneroFav = p_genero_fav;

        //Call to ClienteCAD

        oid = _IClienteCAD.New_ (clienteEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
