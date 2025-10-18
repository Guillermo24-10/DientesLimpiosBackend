namespace DientesLimpios.Application.Interfaces.Repositorio
{
    public interface IRepositorioGeneric<T> where T : class
    {
        Task<T> ObtenerPorId(Guid id);
        Task<IEnumerable<T>> ObtenerTodos();
        Task<T> Crear(T entidad);
        Task Actualizar(T entidad);
        Task Eliminar(T id);
    }
}
