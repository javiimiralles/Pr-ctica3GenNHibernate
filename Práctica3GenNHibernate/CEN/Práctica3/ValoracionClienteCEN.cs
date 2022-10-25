

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
 *      Definition of the class ValoracionClienteCEN
 *
 */
public partial class ValoracionClienteCEN
{
private IValoracionClienteCAD _IValoracionClienteCAD;

public ValoracionClienteCEN()
{
        this._IValoracionClienteCAD = new ValoracionClienteCAD ();
}

public ValoracionClienteCEN(IValoracionClienteCAD _IValoracionClienteCAD)
{
        this._IValoracionClienteCAD = _IValoracionClienteCAD;
}

public IValoracionClienteCAD get_IValoracionClienteCAD ()
{
        return this._IValoracionClienteCAD;
}

public void Modify (int p_ValoracionCliente_OID, double p_valoracion)
{
        ValoracionClienteEN valoracionClienteEN = null;

        //Initialized ValoracionClienteEN
        valoracionClienteEN = new ValoracionClienteEN ();
        valoracionClienteEN.Id = p_ValoracionCliente_OID;
        valoracionClienteEN.Valoracion = p_valoracion;
        //Call to ValoracionClienteCAD

        _IValoracionClienteCAD.Modify (valoracionClienteEN);
}

public void Destroy (int id
                     )
{
        _IValoracionClienteCAD.Destroy (id);
}

public ValoracionClienteEN ReadOID (int id
                                    )
{
        ValoracionClienteEN valoracionClienteEN = null;

        valoracionClienteEN = _IValoracionClienteCAD.ReadOID (id);
        return valoracionClienteEN;
}

public System.Collections.Generic.IList<ValoracionClienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionClienteEN> list = null;

        list = _IValoracionClienteCAD.ReadAll (first, size);
        return list;
}
}
}
