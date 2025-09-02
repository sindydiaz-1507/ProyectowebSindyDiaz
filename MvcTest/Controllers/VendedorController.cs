using Microsoft.AspNetCore.Mvc;
using LunaBisu.Models;

namespace LunaBisu.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "vendedor")
                return RedirectToAction("AccesoDenegado", "Home");

            ViewBag.Mensaje = "Panel de vendedora LunaBisú 🛍️";
            return View();
        }

        public IActionResult MisProductos()
        {
            var rol = HttpContext.Session.GetString("Rol");
            var usuariaId = HttpContext.Session.GetInt32("UsuarioId");

            if (rol != "vendedor" || usuariaId == null)
                return RedirectToAction("AccesoDenegado", "Home");

            // Aquí iría la lógica para mostrar solo los productos de la vendedora
            return View();
        }

        public IActionResult EditarProducto(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "vendedor")
                return RedirectToAction("AccesoDenegado", "Home");

            // Aquí iría la lógica para editar un producto
            return View();
        }

        public IActionResult EliminarProducto(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "vendedor")
                return RedirectToAction("AccesoDenegado", "Home");

            // Aquí iría la lógica para eliminar un producto
            return View();
        }
    }
}