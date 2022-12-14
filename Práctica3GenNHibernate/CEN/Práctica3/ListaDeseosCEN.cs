

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
 *      Definition of the class ListaDeseosCEN
 *
 */
public partial class ListaDeseosCEN
{
private IListaDeseosCAD _IListaDeseosCAD;

public ListaDeseosCEN()
{
        this._IListaDeseosCAD = new ListaDeseosCAD ();
}

public ListaDeseosCEN(IListaDeseosCAD _IListaDeseosCAD)
{
        this._IListaDeseosCAD = _IListaDeseosCAD;
}

public IListaDeseosCAD get_IListaDeseosCAD ()
{
        return this._IListaDeseosCAD;
}

public int New_ (string p_cliente)
{
        ListaDeseosEN listaDeseosEN = null;
        int oid;

        //Initialized ListaDeseosEN
        listaDeseosEN = new ListaDeseosEN ();

        if (p_cliente != null) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                listaDeseosEN.Cliente = new Práctica3GenNHibernate.EN.Práctica3.ClienteEN ();
                listaDeseosEN.Cliente.Email = p_cliente;
        }

        //Call to ListaDeseosCAD

        oid = _IListaDeseosCAD.New_ (listaDeseosEN);
        return oid;
}

public void Modify (int p_ListaDeseos_OID)
{
        ListaDeseosEN listaDeseosEN = null;

        //Initialized ListaDeseosEN
        listaDeseosEN = new ListaDeseosEN ();
        listaDeseosEN.Id = p_ListaDeseos_OID;
        //Call to ListaDeseosCAD

        _IListaDeseosCAD.Modify (listaDeseosEN);
}

public void Destroy (int id
                     )
{
        _IListaDeseosCAD.Destroy (id);
}

public ListaDeseosEN ReadOID (int id
                              )
{
        ListaDeseosEN listaDeseosEN = null;

        listaDeseosEN = _IListaDeseosCAD.ReadOID (id);
        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> list = null;

        list = _IListaDeseosCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN> DameListaDeseosDeCliente (string p_oid_cliente)
{
        return _IListaDeseosCAD.DameListaDeseosDeCliente (p_oid_cliente);
}
public void AgregarProducto (int p_listaDeseos_oid, int p_producto_oid)
{
        //Call to ListaDeseosCAD

        _IListaDeseosCAD.AgregarProducto (p_listaDeseos_oid, p_producto_oid);
}
}
}
