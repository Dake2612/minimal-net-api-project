using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Dario.Robles.Store.Service.Infraestructure.http.Results.Orders
{
    public class GetOrdersResult
    {
        public List<OrderDto> Orders { get; set; }

        public PaginationMetadata PaginationMetadata { get; set; }
    }
}
