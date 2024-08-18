using Dario.Robles.Store.Service.Application.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Dario.Robles.Store.Service.Infraestructure.http.Results.Orders
{
    public class CreateOrderResult
    {
        public ExpandoObject ShapedOrder { get; set; }
        public IDictionary<string, object> LinkedResource { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new();
        public bool Success { get; set; }
    }
}
