using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.Paged;
using System.Dynamic;

namespace Dario.Robles.Store.Service.Infraestructure.http.Results.Orders
{
    public class GetOrdersResult
    {
        public IEnumerable<ExpandoObject> ShapedOrders { get; set; }

        public PaginationMetadata PaginationMetadata { get; set; }

        public LinkedCollectionResource LinkedCollectionResource { get; set; }
    }
}
