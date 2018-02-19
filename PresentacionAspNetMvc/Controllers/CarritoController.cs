using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;
using PresentacionAspNetMvc.Models;

namespace PresentacionAspNetMvc.Controllers
{
    public class CarritoController : Controller
    {
        private EntityMvcContext db = new EntityMvcContext();
        // GET: Carrito
        public ActionResult Index()
        {
            ICarrito carrito = (ICarrito)HttpContext.Session["carrito"];
            return View(carrito);
        }

        public ActionResult AgregarProducto(int id, int cantidad)
        {
            ILogicaNegocio ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];

            ICarrito carrito = (ICarrito)HttpContext.Session["carrito"];

            IProducto producto = db.Productoes.Find(id);

            ln.AgregarProductoACarrito(producto, cantidad, carrito);

            return RedirectToAction("Index");
        }
        //public ActionResult Prueba()
        //{
        //    RedirectToAction("MFactura", "Factura");
        //}
    }
}