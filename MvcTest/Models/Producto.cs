namespace LunaBisu.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? ImagenUrl { get; set; }

        public int CategoriaId { get; set; }
        public string? CategoriaNombre { get; set; }

        public int CreadoraId { get; set; }
        public string? CreadoraNombre { get; set; }
    }
}