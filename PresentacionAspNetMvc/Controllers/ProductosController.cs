using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.LogicaNegocio;
using PresentacionAspNetMvc.Models;
using TiendaVirtual.Entidades;

namespace PresentacionAspNetMvc.Controllers
{
    
    public class ProductosController : Controller
    {
        private EntityMvcContext db = new EntityMvcContext();
        // GET: Productos
        public ActionResult Index()
        {
            //var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            return View(db.Productoes.ToList());
        }

        [HttpGet]
        public ActionResult Ficha(int id)
        {
           
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public string Ficha(int id, int cantidad)
        {
            return $"Los datos recibidos son {id} {cantidad}";
        }
    }
}