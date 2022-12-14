

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Práctica3GenNHibernate.Exceptions;

using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;


namespace Práctica3GenNHibernate.CEN.Práctica3
{
/*
 *      Definition of the class ClienteCEN
 *
 */
public partial class ClienteCEN
{
private IClienteCAD _IClienteCAD;

public ClienteCEN()
{
        this._IClienteCAD = new ClienteCAD ();
}

public ClienteCEN(IClienteCAD _IClienteCAD)
{
        this._IClienteCAD = _IClienteCAD;
}

public IClienteCAD get_IClienteCAD ()
{
        return this._IClienteCAD;
}

public void Modify (string p_Cliente_OID, string p_nombre, string p_apellidos, string p_nombreUsuario, int p_teléfono, String p_pass, int p_puntos, string p_generoFav)
{
        ClienteEN clienteEN = null;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Email = p_Cliente_OID;
        clienteEN.Nombre = p_nombre;
        clienteEN.Apellidos = p_apellidos;
        clienteEN.NombreUsuario = p_nombreUsuario;
        clienteEN.Teléfono = p_teléfono;
        clienteEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        clienteEN.Puntos = p_puntos;
        clienteEN.GeneroFav = p_generoFav;
        //Call to ClienteCAD

        _IClienteCAD.Modify (clienteEN);
}

public void Destroy (string email
                     )
{
        _IClienteCAD.Destroy (email);
}

public ClienteEN ReadOID (string email
                          )
{
        ClienteEN clienteEN = null;

        clienteEN = _IClienteCAD.ReadOID (email);
        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> list = null;

        list = _IClienteCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> ObtenerClientesSinPuntos ()
{
        return _IClienteCAD.ObtenerClientesSinPuntos ();
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> DameClientesPorEmail (string p_email)
{
        return _IClienteCAD.DameClientesPorEmail (p_email);
}
public void AgregarProductoFavorito (string p_Cliente_OID, System.Collections.Generic.IList<int> p_productoFavorito_OIDs)
{
        //Call to ClienteCAD

        _IClienteCAD.AgregarProductoFavorito (p_Cliente_OID, p_productoFavorito_OIDs);
}
public void BorrarProductoFavorito (string p_Cliente_OID, System.Collections.Generic.IList<int> p_productoFavorito_OIDs)
{
        //Call to ClienteCAD

        _IClienteCAD.BorrarProductoFavorito (p_Cliente_OID, p_productoFavorito_OIDs);
}



private string Encode (string email)
{
        var payload = new Dictionary<string, object>(){
                { "email", email }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string email)
{
        ClienteEN en = _IClienteCAD.ReadOIDDefault (email);
        string token = Encode (en.Email);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerEMAIL (decodedToken);

                ClienteEN en = _IClienteCAD.ReadOIDDefault (id);

                if (en != null && ((string)en.Email).Equals (ObtenerEMAIL (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerEMAIL (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string email = (string)results ["email"];
                return email;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
