using System.ComponentModel.DataAnnotations;

namespace AplicacionLibreriaCRUD.Models
{
    public class Producto
    {
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double Costo { get; set; }
        [Required]
        public string Autor {  get; set; }
        [Required]
        public string Descripcion { get; set; }

    }
}