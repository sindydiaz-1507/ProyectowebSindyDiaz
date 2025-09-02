using MySql.Data.MySqlClient;

namespace LunaBisu.Models
{
    public class Conexion
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=lunabisu;user=root;password=";

        public MySqlConnection ObtenerConexion()
        {
            var conexion = new MySqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}