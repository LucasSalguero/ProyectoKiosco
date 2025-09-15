using ProyectoKiosco.BD.Datos;

namespace ProyectoKiosco.Repositorio.Repositorios
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<bool> Existe(int id);
        Task<int> Insert(E entity);
        Task<List<E>> Select();
        Task<E?> SelectById(int id);
        Task<bool> Update(int id, E entity);
    }
}