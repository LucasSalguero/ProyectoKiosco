using ProyectoKiosco.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.BD.Datos
{
    public class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El estado de registro es requerido")]
        public EnumEstadoRegistro EstadoRegistro { get; set; } = EnumEstadoRegistro.EnGrabacion;

        public string Observacion { get; set; } = string.Empty;

    }
}
