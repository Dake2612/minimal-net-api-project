using Dario.Robles.Store.Service.Infraestructure.http.EndpointHandlers;
using System.Runtime.CompilerServices;

namespace Dario.Robles.Store.Service.Infraestructure.http.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterOrdersEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var ordersEndpoints = endpointRouteBuilder
                .MapGroup("api/orders")
                .WithTags("Orders");

            ordersEndpoints.MapGet("", OrdersHandlers.GetOrdersAsync)
                .WithName("GetOrders")
                .WithOpenApi();

            ordersEndpoints.MapGet("/{orderId:guid}", OrdersHandlers.GetOrderByOrderIdAsync)
                .WithName("GetOrder")
                .WithOpenApi();

            ordersEndpoints.MapPost("", OrdersHandlers.CreateOrderAsync)
                .ProducesValidationProblem(422)
                .WithName("CreateOrder")
                .WithOpenApi();

            ordersEndpoints.MapDelete("/{orderId:guid}", OrdersHandlers.DeleteOrderAsync)
                .WithName("DeleteOrder")
                .WithOpenApi();

            ordersEndpoints.MapPut("/{orderId:guid}", OrdersHandlers.UpdateOrderAsync)
                .ProducesValidationProblem(422)
                .WithName("UpdateOrder")
                .WithOpenApi();
        }

        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterOrdersEndpoints();
        }
    }
}
