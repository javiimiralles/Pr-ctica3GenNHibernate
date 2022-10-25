
using System;
using Práctica3GenNHibernate.EN.Práctica3;

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial interface IGeneroCAD
{
GeneroEN ReadOIDDefault (int id
                         );

void ModifyDefault (GeneroEN genero);

System.Collections.Generic.IList<GeneroEN> ReadAllDefault (int first, int size);



int New_ (GeneroEN genero);

void Modify (GeneroEN genero);


void Destroy (int id
              );


GeneroEN ReadOID (int id
                  );


System.Collections.Generic.IList<GeneroEN> ReadAll (int first, int size);
}
}
