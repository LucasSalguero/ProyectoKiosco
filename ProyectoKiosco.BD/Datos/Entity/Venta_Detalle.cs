using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.BD.Datos.Entity
{
    public class Venta_Detalle : EntityBase
    {
        // Claves
        [Required(ErrorMessage = "La venta es requerido")]
        public required int VentaId { get; set; }
        public Venta? Venta { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        public required int ProductoId { get; set; }
        public Producto? Producto { get; set; }


        // prop

        [Required(ErrorMessage = "La cantidad vendida es requerido")]
        public required int Cantidad_vendida { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Column(TypeName = "decimal(10,2)")]
        public required Decimal Precio_unitario { get; set; }


    }
}
