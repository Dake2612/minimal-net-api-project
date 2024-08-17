using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infraestructure.http.Results.Orders;

namespace Dario.Robles.Store.Service.Application.Interfaces
{
    public interface IStoreApplicationService
    {
        Task<GetOrdersResult> GetOrdersAsync(OrdersResourceParameters ordersResourceParameters);
        Task<bool> OrderExitsAsync(Guid orderId);
        Task<CreateOrderResult> CreateOrderAsync(OrderForCreationDto order);
        Task<bool?> DeleteOrderAsync(Guid orderId);
        Task<GetOrderByOrderIdResult> GetOrderByOrderIdAsync(Guid orderId);
        Task<UpdateOrderResult> UpdateOrderAsync(Guid orderId, OrderForUpdateDto order);
    }
}
