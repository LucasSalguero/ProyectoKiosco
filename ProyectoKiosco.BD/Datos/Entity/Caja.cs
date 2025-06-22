using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoKiosco.BD.Datos.Entity
{

    [Index(nameof(Fecha), Name = "Caja_Fecha_UQ", IsUnique = true)]
    public class Caja : EntityBase
    {
        // Clave foranea
        [Required(ErrorMessage = "El usuario es requerido")]
        public required int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "La Fecha es requerido")]
        public required DateTime Fecha { get; set; }
        [Required(ErrorMessage = "La fecha de apertura es requerido")]
        public required DateTime Apertura { get; set; }
        [Required(ErrorMessage = "La fecha de cierre es requerido")]
        public required DateTime Cierre { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Precio { get; set; }

        [Required(ErrorMessage = "El monto total es obligatorio")]
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Monto_total { get; set; }

    }
}
