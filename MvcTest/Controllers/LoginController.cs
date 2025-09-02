using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using LunaBisu.Models;

namespace LunaBisu.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string correo, string contrasena)
        {
            Usuario? usuario = null;

            var conexion = new Conexion();
            using (var conn = conexion.ObtenerConexion())
            {
                var query = "SELECT * FROM usuarios WHERE Correo = @correo AND Contrasena = @contrasena";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"]?.ToString(),
                        Correo = reader["Correo"]?.ToString(),
                        Rol = reader["Rol"]?.ToString(),
                        Contrasena = reader["Contrasena"]?.ToString()
                    };
                }
            }

            if (usuario != null)
            {

                // ✅ Guardar datos en sesión
                HttpContext.Session.SetString("Rol", usuario.Rol!);
                HttpContext.Session.SetString("usuarioId", usuario.Id.ToString());
                Console.WriteLine($"Rol detectado: '{usuario.Rol}'");
                var rol = usuario.Rol?.Trim().ToLower();

                if (rol == "administrador")
                    return RedirectToAction("Index", "Admin");
                else if (rol == "vendedor")
                    return RedirectToAction("Index", "Vendedor");
                else if (rol == "cliente")
                    return RedirectToAction("Index", "Producto");
                else
                    return RedirectToAction("AccesoDenegado", "Home");

            }
            else
            {
                ViewBag.Mensaje = "❌ Usuario o contraseña incorrectos.";
                return View(); // Vuelve al login si falla
            }

        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear(); // 🔒 Limpia toda la sesión
            TempData["Mensaje"] = "👋 Sesión cerrada correctamente.";
            return RedirectToAction("Index", "Login"); // 🔁 Redirige al login
        }
    }
}