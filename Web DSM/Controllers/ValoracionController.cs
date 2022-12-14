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
using Web_DSM.Assemblers;
using Web_DSM.Models;

namespace Web_DSM.Controllers
{
    public class ValoracionController : BasicController
    {
        // GET: Valoracion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Valoracion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Valoracion/Create
        public ActionResult Create(int idProducto)
        {
            ValoracionViewModel val = new ValoracionViewModel();
            Session["idProducto"] = idProducto;
            return View(val);
        }

        // POST: Valoracion/Create
        [HttpPost]
        public ActionResult Create(ValoracionViewModel val)
        {
            try
            {
                ValoracionClienteCP cp = new ValoracionClienteCP();
                string emailCliente = ((ClienteEN)Session["usuario"]).Email;
                cp.New_(val.Valoracion, emailCliente, (int)Session["idProducto"], val.Comentario);
                return RedirectToAction("Details", "Producto", new { id = (int)Session["idProducto"] });
            }
            catch
            {
                return View();
            }
        }

        // GET: Valoracion/Edit/5
        public ActionResult Edit(int idValoracion, int idProducto)
        {
            ValoracionViewModel val = null;
            SessionInitialize();
            Session["idProducto"] = idProducto;
            ValoracionClienteEN valEN = new ValoracionClienteCAD(session).ReadOIDDefault(idValoracion);
            val = new ValoracionAssembler().ConvertENToModelUI(valEN);
            SessionClose();

            return View(val);
        }
    

        // POST: Valoracion/Edit/5
        [HttpPost]
        public ActionResult Edit(ValoracionViewModel val)
        {
            try
            {
                ValoracionClienteCEN cen = new ValoracionClienteCEN();
                cen.Modify(val.IdValoracion, val.Valoracion, val.Comentario);

                return RedirectToAction("Details", "Producto", new { id = (int)Session["idProducto"] });
            }
            catch
            {
                return View();
            }
        }

        // GET: Valoracion/Delete/5
        public ActionResult Delete(int idValoracion, int idProducto)
        {
            try
            {
                // TODO: Add delete logic here
                SessionInitialize();
                ValoracionClienteCAD valCAD = new ValoracionClienteCAD(session);
                ValoracionClienteCEN valCEN = new ValoracionClienteCEN(valCAD);
                SessionClose();
                new ValoracionClienteCEN().Destroy(idValoracion);

                return RedirectToAction("Details", "Producto", new { id = idProducto });
            }
            catch
            {
                return View();
            }
        }

        // POST: Valoracion/Delete/5
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
