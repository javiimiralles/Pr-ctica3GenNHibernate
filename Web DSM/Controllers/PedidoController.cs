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
            PedidoCAD pedCAD = new PedidoCAD();
            PedidoCEN pedCEN = new PedidoCEN(pedCAD);
            IList<PedidoEN> listaPeds = pedCEN.ReadAll(0, -1);
            IList<PedidoEN> pedsCliente = new List<PedidoEN>();
            foreach (PedidoEN ped in listaPeds)
            {
                PedidoEN pedEN = pedCEN.ReadOID(ped.Id);
                string emailPedido = pedEN.Cliente.Email;
                string emailCliente = ((ClienteEN)Session["usuario"]).Email;
                if ((ped.Estado == EstadoPedidoEnum.reparto || ped.Estado == EstadoPedidoEnum.entregado) && emailCliente == emailPedido)
                    pedsCliente.Add(ped);
            }
            IEnumerable<PedidoViewModel> listViewModel = new PedidoAssembler().ConvertListENToModel(pedsCliente).ToList();
            SessionClose();

            return View(listViewModel);
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
                pedidoCP.RealizarPago(idPedido, email, pedido.Direccion, pedido.Localidad, pedido.Provincia, pedido.Codigo_Postal, pedido.Num_Tarjeta, imptotal);

                SessionClose();
                
                return View("ConfirmacionCompra");
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
