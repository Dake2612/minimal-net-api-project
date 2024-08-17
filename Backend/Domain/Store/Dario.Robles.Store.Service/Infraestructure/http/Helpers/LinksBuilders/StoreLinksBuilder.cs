using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.Paged;
using Dario.Robles.Store.Service.Domain.Orders.Entities;

namespace Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public class StoreLinksBuilder : IStoreLinksBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;

        public StoreLinksBuilder(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateOrdersResourceUri(OrdersResourceParameters ordersResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetOrders",
                      new
                      {                          
                          orderBy = ordersResourceParameters.OrderBy,
                          searchQuery = ordersResourceParameters.SearchQuery,
                          state = ordersResourceParameters.State,
                          pageNumber = ordersResourceParameters.PageNumber - 1,
                          pageSize = ordersResourceParameters.PageSize
                      });
                case ResourceUriType.NextPage:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetOrders",
                      new
                      {                          
                          orderBy = ordersResourceParameters.OrderBy,
                          searchQuery = ordersResourceParameters.SearchQuery,
                          state = ordersResourceParameters.State,
                          pageNumber = ordersResourceParameters.PageNumber + 1,
                          pageSize = ordersResourceParameters.PageSize
                      });
                case ResourceUriType.Current:
                default:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetOrders",
                    new
                    {                        
                        orderBy = ordersResourceParameters.OrderBy,
                        searchQuery = ordersResourceParameters.SearchQuery,
                        state = ordersResourceParameters.State,
                        pageNumber = ordersResourceParameters.PageNumber,
                        pageSize = ordersResourceParameters.PageSize
                    });
            }
        }
        public PaginationMetadata GetPaginationMetadata(PagedList<Order> orders, OrdersResourceParameters ordersResourceParameters)
        {
            PaginationMetadata paginationMetadata = new()
            {
                PreviousPageLink = orders.HasPrevious ? CreateOrdersResourceUri(ordersResourceParameters, ResourceUriType.PreviousPage) : null,
                NextPageLink = orders.HasNext ? CreateOrdersResourceUri(ordersResourceParameters, ResourceUriType.NextPage) : null,
                TotalCount = orders.TotalCount,
                PageSize = orders.PageSize,
                CurrentPage = orders.CurrentPage,
                TotalPages = orders.TotalPages,
            };

            return paginationMetadata;
        }                 
    }
}
