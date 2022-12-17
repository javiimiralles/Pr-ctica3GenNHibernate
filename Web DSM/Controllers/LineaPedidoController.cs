using Práctica3GenNHibernate.CAD.Práctica3;
using Práctica3GenNHibernate.CEN.Práctica3;
using Práctica3GenNHibernate.Controllers;
using Práctica3GenNHibernate.CP.Práctica3;
using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DSM.Models;

namespace Web_DSM.Controllers
{
    public class LineaPedidoController : BasicController
    {
        // GET: LineaPedido
        public ActionResult Index()
        {
            return View();
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
                int idPedido = ((PedidoEN)Session["pedido"]).Id;
                cp.New_((int)Session["idProducto"], idPedido, linped.Cantidad);
                SessionClose();

                return RedirectToAction("Details", "Producto", new { id = (int)Session["idProducto"] });
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
            return View();
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
