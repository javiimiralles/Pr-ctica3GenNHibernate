

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
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public void Modify (int p_Pedido_OID, Nullable<DateTime> p_fechaPedido, Nullable<DateTime> p_fechaEntrega, string p_direccion, string p_localidad, string p_provincia, int p_codigoPostal, string p_tipoTarjeta, Práctica3GenNHibernate.Enumerated.Práctica3.EstadoPedidoEnum p_estado, double p_precioTotal)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.FechaPedido = p_fechaPedido;
        pedidoEN.FechaEntrega = p_fechaEntrega;
        pedidoEN.Direccion = p_direccion;
        pedidoEN.Localidad = p_localidad;
        pedidoEN.Provincia = p_provincia;
        pedidoEN.CodigoPostal = p_codigoPostal;
        pedidoEN.TipoTarjeta = p_tipoTarjeta;
        pedidoEN.Estado = p_estado;
        pedidoEN.PrecioTotal = p_precioTotal;
        //Call to PedidoCAD

        _IPedidoCAD.Modify (pedidoEN);
}

public void Destroy (int id
                     )
{
        _IPedidoCAD.Destroy (id);
}

public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoCAD.ReadOID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.PedidoEN> FiltrarPedidoPorProducto (int p_oid_producto)
{
        return _IPedidoCAD.FiltrarPedidoPorProducto (p_oid_producto);
}
}
}
