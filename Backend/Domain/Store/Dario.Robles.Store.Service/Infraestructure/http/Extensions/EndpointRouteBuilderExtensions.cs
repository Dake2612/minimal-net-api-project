using Dario.Robles.Store.Service.Infraestructure.http.EndpointHandlers;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace Dario.Robles.Store.Service.Infraestructure.http.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterOrdersEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var ordersEndpoints = endpointRouteBuilder
                .MapGroup("api/orders")
                .WithTags("Orders")
                .RequireAuthorization();

            ordersEndpoints.MapGet("", OrdersHandlers.GetOrdersAsync)
                .WithName("GetOrders")
                .WithOpenApi()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "realm-role" });

            ordersEndpoints.MapGet("/{orderId:guid}", OrdersHandlers.GetOrderByOrderIdAsync)
                .WithName("GetOrder")
                .WithOpenApi()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "client-role" });

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

        public static void RegisterItemsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var itemsEndpoints = endpointRouteBuilder
                .MapGroup("api/orders/{orderId:guid}/items")
                .WithTags("Items");

            itemsEndpoints.MapGet("", ItemsHandlers.GetItemsForOrderAsync)
                .WithName("GetItemsForOrder")
                .WithOpenApi();

            itemsEndpoints.MapGet("/{itemId:guid}", ItemsHandlers.GetItemByItemIdForOrderAsync)
                .WithName("GetItemForOrder")
                .WithOpenApi();

            itemsEndpoints.MapPost("", ItemsHandlers.CreateItemForOrderAsync)
                .ProducesValidationProblem(422)
                .WithName("CreateItemForOrder")
                .WithOpenApi();

            itemsEndpoints.MapDelete("/{itemId:guid}", ItemsHandlers.DeleteItemForOrderAsync)
               .WithName("DeleteItemForOrder")
               .WithOpenApi();

            itemsEndpoints.MapPut("/{itemId:guid}", ItemsHandlers.UpdateItemForOrderAsync)
                .ProducesValidationProblem(422)
                .WithName("UpdateItemForOrder")
                .WithOpenApi();

            //itemsEndpoints.MapPatch("/{itemId:guid}", ItemsHandlers.PartiallyUpdateItemForOrderAsync)
            //    .ProducesValidationProblem(422)
            //    .WithName("PartiallyUpdateItemForOrder")
            //    .WithOpenApi();
        }

        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterOrdersEndpoints();
            app.RegisterItemsEndpoints();
        }
    }
}
