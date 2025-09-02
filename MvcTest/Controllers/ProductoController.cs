using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using LunaBisu.Models;

namespace LunaBisu.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            var productos = new List<Producto>();
            var conexion = new Conexion();

            using (var conn = conexion.ObtenerConexion())
            {
                var query = @"
                    SELECT p.Id, p.Nombre, p.Descripcion, p.Precio, p.ImagenUrl,
                           p.CategoriaId, c.Nombre AS CategoriaNombre,
                           p.CreadoraId, u.Nombre AS CreadoraNombre
                    FROM productos p
                    JOIN categorias c ON p.CategoriaId = c.Id
                    JOIN usuarios u ON p.CreadoraId = u.Id";

                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"]?.ToString() ?? "",
                        Descripcion = reader["Descripcion"]?.ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        ImagenUrl = reader["ImagenUrl"]?.ToString(),
                        CategoriaId = Convert.ToInt32(reader["CategoriaId"]),
                        CategoriaNombre = reader["CategoriaNombre"]?.ToString(),
                        CreadoraId = Convert.ToInt32(reader["CreadoraId"]),
                        CreadoraNombre = reader["CreadoraNombre"]?.ToString()
                    });
                }
            }

            return View(productos);
        }
    }
}