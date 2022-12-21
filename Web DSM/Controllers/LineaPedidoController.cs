using Práctica3GenNHibernate.CAD.Práctica3;
using Práctica3GenNHibernate.CEN.Práctica3;
using Práctica3GenNHibernate.Controllers;
using Práctica3GenNHibernate.CP.Práctica3;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.Enumerated.Práctica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DSM.Assemblers;
using Web_DSM.Models;

namespace Web_DSM.Controllers
{
    public class LineaPedidoController : BasicController
    {
        // GET: LineaPedido
        public ActionResult Index()
        {
            SessionInitialize();
            PedidoCAD pedCAD = new PedidoCAD(session);
            PedidoCEN pedCEN = new PedidoCEN(pedCAD);

            LineaPedidoCAD linpedCAD = new LineaPedidoCAD(session);
            LineaPedidoCEN linpedCEN = new LineaPedidoCEN(linpedCAD);
            IList<LineaPedidoEN> listaLinpeds = linpedCEN.ReadAll(0, -1);
            IList<LineaPedidoEN> cestaCliente = new List<LineaPedidoEN>();
            foreach(LineaPedidoEN linped in listaLinpeds)
            {
                PedidoEN pedEN = pedCEN.ReadOID(linped.Pedido.Id);
                string emailPedido = pedEN.Cliente.Email;
                string emailCliente = ((ClienteEN)Session["usuario"]).Email;
                if (linped.Pedido.Estado == EstadoPedidoEnum.cesta && emailCliente == emailPedido)
                    cestaCliente.Add(linped);
            }
            IEnumerable<LineaPedidoViewModel> listViewModel = new LineaPedidoAssembler().ConvertListENToModel(cestaCliente).ToList();
            SessionClose();

            return View(listViewModel);
        }

        public ActionResult MisPedidos()
        {
            SessionInitialize();
            PedidoCAD pedCAD = new PedidoCAD(session);
            PedidoCEN pedCEN = new PedidoCEN(pedCAD);

            LineaPedidoCAD linpedCAD = new LineaPedidoCAD(session);
            LineaPedidoCEN linpedCEN = new LineaPedidoCEN(linpedCAD);
            IList<LineaPedidoEN> listaLinpeds = linpedCEN.ReadAll(0, -1);
            IList<LineaPedidoEN> pedsCliente = new List<LineaPedidoEN>();
            foreach (LineaPedidoEN linped in listaLinpeds)
            {
                PedidoEN pedEN = pedCEN.ReadOID(linped.Pedido.Id);
                string emailPedido = pedEN.Cliente.Email;
                string emailCliente = ((ClienteEN)Session["usuario"]).Email;
                if ((linped.Pedido.Estado == EstadoPedidoEnum.reparto || linped.Pedido.Estado == EstadoPedidoEnum.entregado) && emailCliente == emailPedido)
                    pedsCliente.Add(linped);
            }
            IEnumerable<LineaPedidoViewModel> listViewModel = new LineaPedidoAssembler().ConvertListENToModel(pedsCliente).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: LineaPedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LineaPedido/Create
        public ActionResult Create()
        {
            LineaPedidoViewModel linped = new LineaPedidoViewModel();
            return View(linped);
        }

        // POST: LineaPedido/Create
        [HttpPost]
        public ActionResult Create(LineaPedidoViewModel linped)
        {
            try
            {
                SessionInitialize();
                LineaPedidoCP cp = new LineaPedidoCP();

                string email = ((ClienteEN)Session["usuario"]).Email;
                ClienteCAD cliCAD = new ClienteCAD(session);
                ClienteEN cliEN = cliCAD.ReadOID(email);
                IList<PedidoEN> listaPed = cliEN.Pedido;
                int idPedido = 0;
                foreach (PedidoEN pedido in listaPed)
                {
                    if(pedido.Estado == EstadoPedidoEnum.cesta)
                    {
                        idPedido = pedido.Id;
                    }
                }

                int idProducto = (int)Session["idProducto"];

                cp.New_(idProducto, idPedido, linped.Cantidad);
                SessionClose();

                return View("_AnyadidoACesta");
            }
            catch
            {
                return View();
            }
        }

        // GET: LineaPedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineaPedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LineaPedido/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            LineaPedidoCAD linpedCAD = new LineaPedidoCAD(session);
            LineaPedidoCEN linpedCEN = new LineaPedidoCEN(linpedCAD);
            SessionClose();
            new LineaPedidoCEN().Destroy(id);

            return RedirectToAction("Index", "LineaPedido");
        }

        // POST: LineaPedido/Delete/5
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
