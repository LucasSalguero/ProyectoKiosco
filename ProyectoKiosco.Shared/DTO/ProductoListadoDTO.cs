using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.Shared.DTO
{
    public class ProductoListadoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El código es requerido")]
        [MaxLength(50)]
        public string? CodigoProducto { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La cantidad es requerido")]
        public int Cantidad { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

    }
}
