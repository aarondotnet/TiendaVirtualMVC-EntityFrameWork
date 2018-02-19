using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;
using System.Web.Mvc;
using PresentacionAspNetMvc.Models;

namespace PresentacionAspNetMvc.Controllers
{
    public class UsuariosController : Controller
    {
        private EntityMvcContext db = new EntityMvcContext();
        public ActionResult Login(Usuario usuario)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];

            Usuario usuarioCompleto = (from u in db.Usuarios where u.Nick == usuario.Nick && u.Password== usuario.Password select u).FirstOrDefault();
            //IUsuario usuarioCompleto = ln.ValidarUsuarioYDevolverUsuario(usuario.Nick, usuario.Password);
            
            HttpContext.Session["usuario"] = usuarioCompleto;

            ((ICarrito)HttpContext.Session["carrito"]).Usuario = usuarioCompleto;

            return Redirect("/");
        }
    }
}