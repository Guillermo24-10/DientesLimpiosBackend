namespace DientesLimpios.Application.Interfaces.Persistencia
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
