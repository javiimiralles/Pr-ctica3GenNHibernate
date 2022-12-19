using Práctica3GenNHibernate.CAD.Práctica3;
using Práctica3GenNHibernate.CEN.Práctica3;
using Práctica3GenNHibernate.Controllers;
using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DSM.Assemblers;
using Web_DSM.Models;
using Práctica3GenNHibernate.Enumerated.Práctica3;
using Práctica3GenNHibernate.CP.Práctica3;

namespace Web_DSM.Controllers
{
    public class PedidoController : BasicController
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int idPedido, double impTotal)
        {
            PedidoViewModel pedido = null;
            SessionInitialize();
            Session["idPedido"] = idPedido;
            Session["importeTotal"] = impTotal;
            PedidoEN pedEN = new PedidoCAD(session).ReadOIDDefault(idPedido);
            pedido = new PedidoAssembler().ConvertENToModelUI(pedEN);
            SessionClose();

            return View(pedido);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public ActionResult Edit(PedidoViewModel pedido)
        {
            try
            {
                SessionInitialize();
                string email = ((ClienteEN)Session["usuario"]).Email;
                int idPedido = (int)Session["idPedido"];
                double imptotal = (double)Session["importeTotal"];

                PedidoCP pedidoCP = new PedidoCP();
                pedidoCP.RealizarPago(idPedido, email, pedido.Num_Tarjeta);

                PedidoCAD pedidoCAD = new PedidoCAD(session);
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);
                PedidoEN pedidoEN = pedidoCEN.ReadOID(idPedido);

                /*
                LineaPedidoCAD linpedCAD = new LineaPedidoCAD(session);
                LineaPedidoCEN linpedCEN = new LineaPedidoCEN(linpedCAD);
                IList<LineaPedidoEN> listaLinpeds = linpedCEN.ReadAll(0, -1);
                foreach (LineaPedidoEN linped in listaLinpeds)
                {
                    PedidoEN pedEN = pedidoCEN.ReadOID(linped.Pedido.Id);
                    string emailPedido = pedEN.Cliente.Email;
                    if (linped.Pedido.Estado == EstadoPedidoEnum.cesta && email == emailPedido) {
                        ProductoCAD prodCAD = new ProductoCAD(session);
                        ProductoCEN prodCEN = new ProductoCEN(prodCAD);
                        ProductoEN prodEN = prodCEN.ReadOID(linped.Producto.Id);
                        prodEN.Stock -= linped.Cantidad;
                        prodCAD.ModifyDefault(prodEN);
                    }
                }
                */
                pedidoEN.FechaPedido = DateTime.Now;
                pedidoEN.FechaEntrega = DateTime.Now.AddDays(7);
                pedidoEN.Direccion = pedido.Direccion;
                pedidoEN.Localidad = pedido.Localidad;
                pedidoEN.Provincia = pedido.Provincia;
                pedidoEN.CodigoPostal = pedido.Codigo_Postal;
                pedidoEN.TipoTarjeta = pedido.Num_Tarjeta;
                pedidoEN.Estado = EstadoPedidoEnum.reparto;
                pedidoEN.PrecioTotal = imptotal;
                pedidoCAD.ModifyDefault(pedidoEN);

                // Le sumamos puntos al cliente segun lo que se ha gastado
                ClienteCAD clienteCAD = new ClienteCAD(session);
                ClienteCEN clienteCEN = new ClienteCEN(clienteCAD);
                ClienteEN clienteEN = clienteCEN.ReadOID(email);
                clienteEN.Puntos = clienteEN.Puntos + (int)imptotal / 2;
                clienteCAD.ModifyDefault(clienteEN);

                //Reinicializamos la cesta
                PedidoCEN pedidoCEN2 = new PedidoCEN();
                IList<LineaPedidoEN> linpeds = new List<LineaPedidoEN>();
                pedidoCEN2.New_("", "", "", 0, "", email, linpeds);

                SessionClose();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
