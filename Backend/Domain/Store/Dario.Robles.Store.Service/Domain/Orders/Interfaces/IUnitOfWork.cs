namespace Dario.Robles.Store.Service.Domain.Orders.Interfaces
{
    public interface IUnitOfWork
    {
        void Dispose();
        Task<bool> SaveAsync();
    }
}
