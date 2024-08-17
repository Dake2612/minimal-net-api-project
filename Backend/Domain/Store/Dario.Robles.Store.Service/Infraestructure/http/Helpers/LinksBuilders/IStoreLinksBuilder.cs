using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.Paged;
using Dario.Robles.Store.Service.Domain.Orders.Entities;

namespace Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public interface IStoreLinksBuilder
    {
        string CreateOrdersResourceUri(OrdersResourceParameters ordersResourceParameters, ResourceUriType type);        
        PaginationMetadata GetPaginationMetadata(PagedList<Order> orders, OrdersResourceParameters ordersResourceParameters);
    }
}