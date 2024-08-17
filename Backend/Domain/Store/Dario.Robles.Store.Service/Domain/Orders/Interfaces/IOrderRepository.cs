using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Domain.Orders.Entities;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Dario.Robles.Store.Service.Domain.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Task<PagedList<Order>> GetOrdersAsync(OrdersResourceParameters ordersResourceParameters);
        Task<IEnumerable<Order>> GetOrderAsync(List<Guid> ordersIds);
        Task AddOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task<Order> GetOrderAsync(Guid orderId);
        Task<bool> OrderExists(Guid orderId);
    }
}
