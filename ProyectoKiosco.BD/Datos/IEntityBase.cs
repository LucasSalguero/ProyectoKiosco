using ProyectoKiosco.Shared.ENUM;

namespace ProyectoKiosco.BD.Datos
{
    public interface IEntityBase
    {
        EnumEstadoRegistro EstadoRegistro { get; set; }
        int Id { get; set; }
        string Observacion { get; set; }
    }
}