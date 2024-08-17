using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Application.Interfaces;
using Dario.Robles.Store.Service.Infraestructure.http.Results.Orders;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Dario.Robles.Store.Service.Infraestructure.http.EndpointHandlers
{
    public static class OrdersHandlers
    {
        public static async Task<Results<BadRequest, Ok<List<OrderDto>>>> GetOrdersAsync(
            [FromServices] IStoreApplicationService _storeApplicationService, 
            [AsParameters] OrdersResourceParameters ordersResourceParameters,
            [FromServices] IHttpContextAccessor _httpContextAccessor,
            [FromServices] IOrderPropertyMappingService _orderPropertyMappingService)
        {
            if (!_orderPropertyMappingService.ValidMappingExistsFor(ordersResourceParameters.OrderBy))
            {
                return TypedResults.BadRequest();
            }
            var result = await _storeApplicationService.GetOrdersAsync(ordersResourceParameters);
            _httpContextAccessor.HttpContext.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.PaginationMetadata, new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));

            return TypedResults.Ok(result.Orders);
        }

        public static async Task<Results<BadRequest, Ok<OrderDto>>> GetOrderByOrderIdAsync([FromServices] IStoreApplicationService _storeApplicationService, Guid orderId)
        {
            var result = await _storeApplicationService.GetOrderByOrderIdAsync(orderId);
            return TypedResults.Ok(result.Order);
        }

        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<OrderDto>, Ok<OrderDto>>> CreateOrderAsync([FromServices] IStoreApplicationService _storeApplicationService, [FromBody] OrderForCreationDto order)
        {
            if (order == null)
            {
                return TypedResults.BadRequest();
            }
            var result = await _storeApplicationService.CreateOrderAsync(order);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            return TypedResults.CreatedAtRoute(result.Order, $"GetOrder", new { result.Order.OrderId });
        }

        public static async Task<Results<NotFound, NoContent>> DeleteOrderAsync([FromServices] IStoreApplicationService _storeApplicationService, Guid orderId)
        {
            var result = await _storeApplicationService.DeleteOrderAsync(orderId);

            if (result == null)
                return TypedResults.NotFound();

            return TypedResults.NoContent();
        }

        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<OrderDto>, UnprocessableEntity<List<ValidationResult>>, Ok<OrderDto>>> UpdateOrderAsync([FromServices] IStoreApplicationService _storeApplicationService, [FromBody] OrderForUpdateDto order, Guid orderId)
        {
            if (order == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _storeApplicationService.UpdateOrderAsync(orderId, order);

            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            if (result.Success && result.OrderUpserted != null)
            {
                return TypedResults.CreatedAtRoute(result.OrderUpserted, $"GetOrder", new { orderId = result.OrderUpserted.OrderId });
            }

            return TypedResults.NoContent();
        }
    }

}
