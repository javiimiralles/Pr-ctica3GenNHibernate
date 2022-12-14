using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DSM.Models;

namespace Web_DSM.Assemblers
{
    public class ValoracionAssembler
    {
        public ValoracionViewModel ConvertENToModelUI(ValoracionClienteEN en)
        {
            ValoracionViewModel val = new ValoracionViewModel();
            val.IdValoracion = en.Id;
            val.IdProducto = en.Producto.Id;
            val.IdCliente = en.Cliente.Email;
            val.Valoracion = en.Valoracion;
            val.Comentario = en.Comentario;

            return val;
        }

        public IList<ValoracionViewModel> ConvertListENToModel(IList<ValoracionClienteEN> ens)
        {
            IList<ValoracionViewModel> vals = new List<ValoracionViewModel>();
            foreach (ValoracionClienteEN en in ens)
            {
                vals.Add(ConvertENToModelUI(en));
            }
            return vals;
        }
    }
}