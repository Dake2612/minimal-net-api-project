using Dario.Robles.Store.Service.Application.Dtos;
using System.Dynamic;

namespace Dario.Robles.Store.Service.Infraestructure.http.Results.Orders
{
    public class GetOrderByOrderIdResult
    {
        public ExpandoObject ShapedOrder { get; set; }

        public IDictionary<string, object> LinkedResource { get; set; }
    }
}
