using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.BD.Datos.Entity
{

    [Index(nameof(CodigoProducto), Name = "Producto_Codigo_UQ", IsUnique = true)]
    public class Producto : EntityBase
    {

        [Required(ErrorMessage = "El código es requerido")]
        [MaxLength(50)]
        public required string CodigoProducto { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "La cantidad es requerido")]
        public required int Cantidad { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Precio { get; set; }

    }
}
