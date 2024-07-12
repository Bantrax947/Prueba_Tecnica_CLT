using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public decimal Precio { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        [StringLength(50)]
        public string Categoria { get; set; } = string.Empty;

        [StringLength(100)]
        public string? ImagenUrl { get; set; }
    }
}
