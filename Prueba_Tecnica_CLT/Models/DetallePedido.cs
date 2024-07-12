using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    [Table("detalle_pedido")]
    public class DetallePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; } = new Pedido();

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; } = new Producto();

    
    }
}
