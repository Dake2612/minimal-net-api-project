using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Domain.Orders.Entities;
using Dario.Robles.Store.Service.Domain.Orders.Interfaces;
using Dario.Robles.Store.Service.Infraestructure.Persistence.Contexts;
using Dario.Robles.Store.Service.Infraestructure.Persistence.Extensions;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.Paged;
using Microsoft.EntityFrameworkCore;

namespace Dario.Robles.Store.Service.Infraestructure.Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _context;
        private readonly IOrderPropertyMappingService _authorPropertyMappingService;
        public OrderRepository(
            StoreContext context,
            IOrderPropertyMappingService propertyMappingService)
        {
            _context = context;
            _authorPropertyMappingService = propertyMappingService;
        }

        public async Task<PagedList<Order>> GetOrdersAsync(OrdersResourceParameters ordersResourceParameters)
        {
            var collectionBeforePaging = _context.Orders.ApplySort(ordersResourceParameters.OrderBy, _authorPropertyMappingService.GetPropertyMapping());

            if (!string.IsNullOrEmpty(ordersResourceParameters.State))
            {
                var stateForWhereClause = ordersResourceParameters.State.Trim().ToLower();
                collectionBeforePaging = collectionBeforePaging.Where(s => s.State.ToLower().Equals(stateForWhereClause));
            }

            if (!string.IsNullOrEmpty(ordersResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = ordersResourceParameters.SearchQuery.Trim().ToLower();
                collectionBeforePaging = collectionBeforePaging.Where(s => s.Code.ToLower().Contains(searchQueryForWhereClause)
                || s.State.ToLower().Contains(searchQueryForWhereClause));
            }
            return await PagedList<Order>.CreateAsync(collectionBeforePaging,
                ordersResourceParameters.PageNumber.Value,
                ordersResourceParameters.PageSize.Value);
        }

        public async Task<IEnumerable<Order>> GetOrderAsync(List<Guid> ordersIds)
        {
            return await _context.Orders.Where(a => ordersIds.Contains(a.OrderId))
                .OrderBy(a => a.Code)
                .OrderBy(a => a.State)
                .ToListAsync();
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task DeleteOrderAsync(Order order)
        {
            await Task.FromResult(_context.Orders.Remove(order));
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var orderUpdate = await GetOrderAsync(order.OrderId);
            if (orderUpdate != null)
            {
                orderUpdate.Code = order.Code;
                orderUpdate.State = order.State;
                orderUpdate.DeliverAt = order.DeliverAt;
                orderUpdate.CreatedAt = order.CreatedAt;
            }
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(a => a.OrderId == orderId);
        }

        public async Task<bool> OrderExists(Guid orderId)
        {
            return await _context.Orders.AnyAsync(a => a.OrderId == orderId);
        }
    }
}
