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

namespace Web_DSM.Controllers
{
    public class ClienteController : BasicController
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteCAD cliCAD = new ClienteCAD();
            ClienteCEN cliCEN = new ClienteCEN(cliCAD);
            ClienteEN cliEN = cliCEN.ReadOID(((ClienteEN)Session["usuario"]).Email);
            ClienteViewModel cliVM = new ClienteAssembler().ConvertENToModelUI(cliEN);

            return View(cliVM);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
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

        // GET: Cliente/Edit/5
        public ActionResult Edit(string email)
        {
            ClienteViewModel cli = null;
            SessionInitialize();
            ClienteEN cliEN = new ClienteCAD(session).ReadOIDDefault(email);
            cli = new ClienteAssembler().ConvertENToModelUI(cliEN);
            SessionClose();

            return View(cli);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            try
            {
                ClienteCEN cen = new ClienteCEN();
                int puntos = ((ClienteEN)Session["usuario"]).Puntos;
                string password = ((ClienteEN)Session["usuario"]).Pass;
                cen.Modify(cliente.Email, cliente.Nombre, cliente.Apellidos, cliente.NombreUsuario, int.Parse(cliente.Telefono), password, puntos, cliente.Genero);

                return RedirectToAction("Index", "Cliente");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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
