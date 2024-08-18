using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.Paged;
using Dario.Robles.Store.Service.Domain.Orders.Entities;
using System.Dynamic;

namespace Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public interface IStoreLinksBuilder
    {
        string CreateOrdersResourceUri(OrdersResourceParameters ordersResourceParameters, ResourceUriType type);        
        PaginationMetadata GetPaginationMetadata(PagedList<Order> orders, OrdersResourceParameters ordersResourceParameters);
        IEnumerable<LinkDto> CreatePagedLinksForOrders(OrdersResourceParameters ordersResourceParameters, bool hasNext, bool hasPrevious);
        IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForOrderShapeData(IEnumerable<ExpandoObject> shapedOrders, OrdersResourceParameters ordersResourceParameters);
        List<LinkDto> CreateDocumentationLinksForOrder(Guid orderId, string fields);
    }
}