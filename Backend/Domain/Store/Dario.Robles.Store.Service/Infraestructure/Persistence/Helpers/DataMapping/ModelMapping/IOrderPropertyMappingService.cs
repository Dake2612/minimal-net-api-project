using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping;
using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Domain.Orders.Entities;

namespace Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping
{
    public interface IOrderPropertyMappingService : IPropertyMappingService<OrderDto, Order>
    {

    }
}
