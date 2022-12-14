using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DSM.Models;

namespace Web_DSM.Assemblers
{
    public class ProductoAssembler
    {
        public ProductoViewModel ConvertENToModelUI(ProductoEN en)
        {
            ProductoViewModel prod = new ProductoViewModel();
            prod.Id = en.Id;
            prod.Nombre = en.Nombre;
            prod.Descripcion = en.Descripcion;
            prod.Precio = en.Precio;
            prod.Stock = en.Stock;
            prod.ValoracionMedia = en.ValoracionMedia;
            prod.Genero = en.Genero.Nombre;
            prod.Imagen = en.Imagen;
            prod.Comentarios = new List<string>();
            prod.NombreUsuario = new List<string>();
            prod.IdValoracionCliente = new List<int>();
            prod.ValoracionCliente = new List<double>();
            prod.EmailUsuario = new List<string>();

            foreach (var valoracion in en.ValoracionCliente)
            {
                prod.ValoracionCliente.Add(valoracion.Valoracion);
                prod.IdValoracionCliente.Add(valoracion.Id);
                prod.Comentarios.Add(valoracion.Comentario);
                prod.NombreUsuario.Add(valoracion.Cliente.NombreUsuario);
                prod.EmailUsuario.Add(valoracion.Cliente.Email);
            }

            return prod;
        }

        public IList<ProductoViewModel> ConvertListENToModel(IList<ProductoEN> ens)
        {
            IList<ProductoViewModel> prods = new List<ProductoViewModel>();
            foreach (ProductoEN en in ens)
            {
                prods.Add(ConvertENToModelUI(en));
            }
            return prods;
        }
    }
}