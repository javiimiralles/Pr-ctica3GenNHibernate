using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DSM.Models;

namespace Web_DSM.Assemblers
{
    public class ClienteAssembler
    {
        public ClienteViewModel ConvertENToModelUI(ClienteEN en)
        {
            ClienteViewModel cliente = new ClienteViewModel();
            cliente.Email = en.Email;
            cliente.Nombre = en.Nombre;
            cliente.Apellidos = en.Apellidos;
            cliente.NombreUsuario = en.NombreUsuario;
            cliente.Telefono = en.Telefono.ToString();
            cliente.Genero = en.GeneroFav;
            cliente.Puntos = en.Puntos;

            return cliente;
        }

        public IList<ClienteViewModel> ConvertListENToModel(IList<ClienteEN> ens)
        {
            IList<ClienteViewModel> clientes = new List<ClienteViewModel>();
            foreach (ClienteEN en in ens)
            {
                clientes.Add(ConvertENToModelUI(en));
            }
            return clientes;
        }
    }
}