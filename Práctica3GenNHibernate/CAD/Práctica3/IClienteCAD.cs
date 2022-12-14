
using System;
using Práctica3GenNHibernate.EN.Práctica3;

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial interface IClienteCAD
{
ClienteEN ReadOIDDefault (string email
                          );

void ModifyDefault (ClienteEN cliente);

System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size);



string New_ (ClienteEN cliente);

void Modify (ClienteEN cliente);


void Destroy (string email
              );


ClienteEN ReadOID (string email
                   );


System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size);



System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> ObtenerClientesSinPuntos ();


System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ClienteEN> DameClientesPorEmail (string p_email);


void AgregarProductoFavorito (string p_Cliente_OID, System.Collections.Generic.IList<int> p_productoFavorito_OIDs);

void BorrarProductoFavorito (string p_Cliente_OID, System.Collections.Generic.IList<int> p_productoFavorito_OIDs);
}
}
