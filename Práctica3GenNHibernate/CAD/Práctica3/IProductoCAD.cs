
using System;
using Práctica3GenNHibernate.EN.Práctica3;

namespace Práctica3GenNHibernate.CAD.Práctica3
{
public partial interface IProductoCAD
{
ProductoEN ReadOIDDefault (int id
                           );

void ModifyDefault (ProductoEN producto);

System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size);



int New_ (ProductoEN producto);

void Modify (ProductoEN producto);


void Destroy (int id
              );


ProductoEN ReadOID (int id
                    );


System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size);






System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> FiltrarPorPrecioAsc ();


System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> FiltrarPorValoracion ();


System.Collections.Generic.IList<Práctica3GenNHibernate.EN.Práctica3.ProductoEN> FiltrarPorPrecioDesc ();


void AsignarGenero (int p_Producto_OID, System.Collections.Generic.IList<int> p_genero_OIDs);

void DesasignarGenero (int p_Producto_OID, System.Collections.Generic.IList<int> p_genero_OIDs);
}
}
