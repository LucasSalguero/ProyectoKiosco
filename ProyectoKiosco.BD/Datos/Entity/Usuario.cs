using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKiosco.BD.Datos.Entity
{

    [Index(nameof(DNI), Name = "Usuario_DNI_UQ", IsUnique = true)]
    [Index(nameof(Email), Name = "Usuario_Email_UQ", IsUnique = true)]
    public class Usuario : EntityBase
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        public required string Apellido { get; set; }
        [Required(ErrorMessage = "El Email es requerido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "El dni es requerido")]
        [MaxLength(8, ErrorMessage ="El dni tiene como maximo {1} caracteres")]
        public required string DNI { get; set; }

        [Required(ErrorMessage = "Seleccione su rol")]
        public bool EsAdmin { get; set; }
    }
}
