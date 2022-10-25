
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
}
}
