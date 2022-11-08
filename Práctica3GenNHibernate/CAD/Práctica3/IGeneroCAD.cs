
using System;
using Práctica3GenNHibernate.EN.Práctica3;

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial interface IGeneroCAD
{
GeneroEN ReadOIDDefault (string nombre
                         );

void ModifyDefault (GeneroEN genero);

System.Collections.Generic.IList<GeneroEN> ReadAllDefault (int first, int size);



string New_ (GeneroEN genero);

void Modify (GeneroEN genero);


void Destroy (string nombre
              );


GeneroEN ReadOID (string nombre
                  );


System.Collections.Generic.IList<GeneroEN> ReadAll (int first, int size);
}
}
