using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.BD.Datos.Entity
{
    public class Venta : EntityBase
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public required int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "La Fecha es requerido")]
        public required DateTime Fecha_hora { get; set; }

        [Required(ErrorMessage = "El monto es requerido")]
        [Column(TypeName = "decimal(10,2)")]
        public required Decimal Monto { get; set; }



    }
}
