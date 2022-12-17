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
    public class ProductoController : BasicController
    {
        // GET: Producto
        public ActionResult Index()
        {
            SessionInitialize();
            ProductoCAD prodCAD = new ProductoCAD(session);
            ProductoCEN prodCEN = new ProductoCEN(prodCAD);

            IList<ProductoEN> listaProductos = prodCEN.ReadAll(0, -1);
            IEnumerable<ProductoViewModel> listViewModel = new ProductoAssembler().ConvertListENToModel(listaProductos).ToList();

            SessionClose();

            return View(listViewModel);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            ProductoViewModel prod = null;
            SessionInitialize();
            ProductoEN prodEN = new ProductoCAD(session).ReadOIDDefault(id);
            prod = new ProductoAssembler().ConvertENToModelUI(prodEN);
            SessionClose();
            return View(prod);
        }

        // GET: /ProductoViewModels/productoFavorito/5
        public ActionResult ListaFavoritos()
        {
            SessionInitialize();
            ProductoCAD prodCAD = new ProductoCAD(session);
            ProductoCEN prodCEN = new ProductoCEN(prodCAD);
            string emailCliente = ((ClienteEN)Session["usuario"]).Email;
            IList<ProductoEN> listProdEn = prodCEN.DameListaFavoritosCliente(emailCliente);
            IEnumerable<ProductoViewModel> listViewModel = new ProductoAssembler().ConvertListENToModel(listProdEn).ToList();

            SessionClose();

            return View(listViewModel);
        }

        // POST: ListaFavoritos/Create
       
        public ActionResult AnyadirAFavoritos(int idProducto)
        {
            ClienteCEN cliCEN = new ClienteCEN();
            string emailCliente = ((ClienteEN)Session["usuario"]).Email;
            IList<int> idProds = new List<int>();
            idProds.Add(idProducto);
            cliCEN.AgregarProductoFavorito(emailCliente, idProds);

            return RedirectToAction("Details", "Producto", new { id = idProducto });
        }

        public ActionResult QuitarDeFavoritos(int idProducto)
        {
            ClienteCEN cliCEN = new ClienteCEN();
            string emailCliente = ((ClienteEN)Session["usuario"]).Email;
            IList<int> idProds = new List<int>();
            idProds.Add(idProducto);
            cliCEN.BorrarProductoFavorito(emailCliente, idProds);

            return RedirectToAction("Details", "Producto", new { id = idProducto });
        }

        // GET: /ProductoViewModels/Genero/5
        public ActionResult PorGenero(string genero)
        {
            SessionInitialize();
            ProductoCAD prodCAD = new ProductoCAD(session);
            GeneroCAD genCAD = new GeneroCAD(session);
            ProductoCEN prodCEN = new ProductoCEN(prodCAD);
            IList<ProductoEN> listProdEn = prodCEN.DameProductosPorGenero(genero);
            IEnumerable<ProductoViewModel> listProd = new ProductoAssembler().ConvertListENToModel(listProdEn).ToList();
            GeneroEN genEN = genCAD.ReadOIDDefault(genero);

            if (genEN != null)
                ViewData["Genero"] = genero;

            SessionClose();
            return View(listProd);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
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

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
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

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
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
