
using System;
using Práctica3GenNHibernate.EN.Práctica3;

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial interface IListaDeseosCAD
{
ListaDeseosEN ReadOIDDefault (int id
                              );

void ModifyDefault (ListaDeseosEN listaDeseos);

System.Collections.Generic.IList<ListaDeseosEN> ReadAllDefault (int first, int size);



int New_ (ListaDeseosEN listaDeseos);

void Modify (ListaDeseosEN listaDeseos);


void Destroy (int id
              );


ListaDeseosEN ReadOID (int id
                       );


System.Collections.Generic.IList<ListaDeseosEN> ReadAll (int first, int size);


System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ListaDeseosEN> DameListaDeseosDeCliente (string p_oid_cliente);


void AgregarProducto (int p_listaDeseos_oid, int p_producto_oid);
}
}
