using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infraestructure.http.Results.Items;
using Dario.Robles.Store.Service.Infraestructure.http.Results.Orders;
using Microsoft.AspNetCore.JsonPatch;

namespace Dario.Robles.Store.Service.Application.Interfaces
{
    public interface IStoreApplicationService
    {
        Task<GetOrdersResult> GetOrdersAsync(OrdersResourceParameters ordersResourceParameters);
        Task<bool> OrderExitsAsync(Guid orderId);
        Task<CreateOrderResult> CreateOrderAsync(OrderForCreationDto order);
        Task<bool?> DeleteOrderAsync(Guid orderId);
        Task<GetOrderByOrderIdResult> GetOrderByOrderIdAsync(Guid orderId, string fields);
        Task<UpdateOrderResult> UpdateOrderAsync(Guid orderId, OrderForUpdateDto order);

        Task<GetItemsForOrderResult> GetItemsForOrderAsync(Guid itemId);
        Task<GetItemForOrderResult> GetItemByItemIdForOrderAsync(Guid orderId, Guid itemId);
        Task<CreateItemForOrderResult> CreateItemForOrderAsync(Guid orderId, ItemForCreationDto itemDto);
        Task<DeleteItemForOrderResult> DeleteItemForOrderAsync(Guid orderId, Guid itemId);
        Task<UpdateItemForOrderResult> UpdateItemForOrderAsync(Guid orderId, Guid itemId, ItemForUpdateDto itemDto);
        Task<PartiallyUpdateItemForOrderResult> PartiallyUpdateItemForOrder(Guid orderId, Guid itemId, JsonPatchDocument<ItemForUpdateDto> patchDoc);
    }
}
