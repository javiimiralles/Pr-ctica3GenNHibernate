
using System;
using Práctica3GenNHibernate.EN.Práctica3;

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial interface IValoracionClienteCAD
{
ValoracionClienteEN ReadOIDDefault (int id
                                    );

void ModifyDefault (ValoracionClienteEN valoracionCliente);

System.Collections.Generic.IList<ValoracionClienteEN> ReadAllDefault (int first, int size);



int New_ (ValoracionClienteEN valoracionCliente);

void Modify (ValoracionClienteEN valoracionCliente);


void Destroy (int id
              );


ValoracionClienteEN ReadOID (int id
                             );


System.Collections.Generic.IList<ValoracionClienteEN> ReadAll (int first, int size);
}
}
