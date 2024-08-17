using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Domain.Orders.Entities;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping;

namespace Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping
{
    public class OrderPropertyMappingService : PropertyMappingService<OrderDto, Order>, IOrderPropertyMappingService
    {
        private static Dictionary<string, PropertyMappingValue> _orderPropertyMapping =
           new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
           {
               { "Id", new PropertyMappingValue(new List<string>() { "OrderId" } ) },
               { "Code", new PropertyMappingValue(new List<string>() { "Code" } )},
               { "State", new PropertyMappingValue(new List<string>() { "State" } , true) },
               { "CreatedAt", new PropertyMappingValue(new List<string>() { "CreatedAt" } ) }
           };
        public OrderPropertyMappingService() : base(_orderPropertyMapping)
        {

        }
    }
}
