using Microsoft.AspNetCore.Mvc;
using LunaBisu.Models;

namespace LunaBisu.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "administrador")
                return RedirectToAction("AccesoDenegado", "Home");

            ViewBag.Mensaje = "Panel de administración LunaBisú ";
            return View();
        }

        public IActionResult GestionarProductos()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "administrador")
                return RedirectToAction("AccesoDenegado", "Home");

            // Aquí iría la lógica para listar todos los productos
            return View();
        }

        public IActionResult VerPedidos()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "administrador")
                return RedirectToAction("AccesoDenegado", "Home");

            // Aquí iría la lógica para mostrar todos los pedidos
            return View();
        }

        public IActionResult GestionarUsuarios()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "administrador")
                return RedirectToAction("AccesoDenegado", "Home");

            // Aquí iría la lógica para mostrar y editar usuarios
            return View();
        }
    }
}