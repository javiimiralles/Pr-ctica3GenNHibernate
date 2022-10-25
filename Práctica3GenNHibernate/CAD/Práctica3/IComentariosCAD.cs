
using System;
using Práctica3GenNHibernate.EN.Práctica3;

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial interface IComentariosCAD
{
ComentariosEN ReadOIDDefault (int id
                              );

void ModifyDefault (ComentariosEN comentarios);

System.Collections.Generic.IList<ComentariosEN> ReadAllDefault (int first, int size);



int New_ (ComentariosEN comentarios);

void Modify (ComentariosEN comentarios);


void Destroy (int id
              );


ComentariosEN ReadOID (int id
                       );


System.Collections.Generic.IList<ComentariosEN> ReadAll (int first, int size);
}
}
