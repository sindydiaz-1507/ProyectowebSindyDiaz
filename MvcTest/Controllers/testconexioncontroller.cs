using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using LunaBisu.Models; // si usas la clase Conexion.cs

public class TestConexionController : Controller
{
    public IActionResult Index()
    {
        try
        {
            var conexion = new Conexion(); // tu clase estilo config.php
            using (var conn = conexion.ObtenerConexion())
            {
                return Content("✅ Conexión exitosa con la base de datos LunaBisú.");
            }
        }
        catch (Exception ex)
        {
            return Content("❌ Error de conexión: " + ex.Message);
        }
    }
}