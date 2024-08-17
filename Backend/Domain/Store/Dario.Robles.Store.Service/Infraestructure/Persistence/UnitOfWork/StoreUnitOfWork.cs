using Dario.Robles.Store.Service.Domain.Orders.Interfaces;
using Dario.Robles.Store.Service.Infraestructure.Persistence.Contexts;

namespace Dario.Robles.Store.Service.Infraestructure.Persistence.UnitOfWork
{
    public class StoreUnitOfWork : UnitOfWork
    {
        public IOrderRepository Orders { get; }
        public IItemRepository Items { get; }
        public StoreContext _context { get; }

        public StoreUnitOfWork(
            StoreContext context,
            IOrderRepository orderRepository,
            IItemRepository itemRepository
        ) : base(context)
        {
            _context = context;
            Orders = orderRepository;
            Items = itemRepository;
        }
    }
}
