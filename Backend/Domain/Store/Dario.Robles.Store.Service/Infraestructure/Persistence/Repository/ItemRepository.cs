using Dario.Robles.Store.Service.Domain.Orders.Entities;
using Dario.Robles.Store.Service.Domain.Orders.Interfaces;
using Dario.Robles.Store.Service.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Dario.Robles.Store.Service.Infraestructure.Persistence.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly StoreContext _context;
        public ItemRepository(
            StoreContext context
        )
        {
            _context = context;
        }
        public async Task AddItemForOrderAsync(Guid orderId, Item item)
        {
            item.OrderId = orderId;
            await _context.Items.AddAsync(item);
        }
        public async Task DeleteItemAsync(Item item)
        {
            await Task.FromResult(_context.Items.Remove(item));
        }
        public async Task UpdateItemForOrderAsync(Item item)
        {
            Item itemUpdate = await GetItemForOrderAsync(item.OrderId, item.ItemId);
            if (itemUpdate != null)
            {
                itemUpdate.Name = item.Name;
                itemUpdate.Quantity = item.Quantity;
            }
        }
        public async Task<IEnumerable<Item>> GetItemsForOrderAsync(Guid orderId)
        {
            return await _context.Items.Where(b => b.OrderId == orderId).OrderBy(b => b.Name).ToListAsync();
        }
        public async Task<Item> GetItemForOrderAsync(Guid orderId, Guid itemId)
        {
            return await _context.Items.Where(b => b.OrderId == orderId && b.ItemId == itemId).FirstOrDefaultAsync();
        }

        public Task<Item> UpdateBookAsync(Item item)
        {
            _context.Items.Update(item);
            return Task.FromResult(item);
        }
    }
}
