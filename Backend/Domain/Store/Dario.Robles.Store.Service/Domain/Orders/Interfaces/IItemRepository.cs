using Dario.Robles.Store.Service.Domain.Orders.Entities;

namespace Dario.Robles.Store.Service.Domain.Orders.Interfaces
{
    public interface IItemRepository
    {
        Task AddItemForOrderAsync(Guid orderId, Item item);
        Task DeleteItemAsync(Item item);
        Task UpdateItemForOrderAsync(Item item);
        Task<IEnumerable<Item>> GetItemsForOrderAsync(Guid orderId);
        Task<Item> GetItemForOrderAsync(Guid orderId, Guid itemId);
        Task<Item> UpdateBookAsync(Item item);
    }
}
