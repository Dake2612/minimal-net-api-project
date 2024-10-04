using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Application.Interfaces;
using Dario.Robles.Store.Service.Infraestructure.http.Results.Orders;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text.Json;

namespace Dario.Robles.Store.Service.Infraestructure.http.EndpointHandlers
{
    public static class OrdersHandlers
    {
        public static async Task<Results<BadRequest, Ok<IEnumerable<ExpandoObject>>, Ok<LinkedCollectionResource> ,Ok<List<OrderDto>>>> GetOrdersAsync(
            [FromServices] IStoreApplicationService _storeApplicationService, 
            [AsParameters] OrdersResourceParameters ordersResourceParameters,
            [FromServices] IHttpContextAccessor _httpContextAccessor,
            [FromHeader(Name = "Accept")] string? mediaType,
            [FromServices] IOrderPropertyMappingService _orderPropertyMappingService,
            [FromServices] ITypeHelperService _typeHelperService)
        {
            if (!_orderPropertyMappingService.ValidMappingExistsFor(ordersResourceParameters.OrderBy) || !_typeHelperService.TypeHasProperties<OrderDto>(ordersResourceParameters.Fields))
            {
                return TypedResults.BadRequest();
            }
            var result = await _storeApplicationService.GetOrdersAsync(ordersResourceParameters);
            _httpContextAccessor.HttpContext.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.PaginationMetadata, new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, PropertyNamingPolicy = JsonNamingPolicy.CamelCase}));

            switch (mediaType)
            {
                case "application/vnd.dario.hateoas+json":
                    return TypedResults.Ok(result.LinkedCollectionResource);
                default:
                    return TypedResults.Ok(result.ShapedOrders);
            }
        }

        public static async Task<Results<BadRequest, Ok<ExpandoObject>, Ok<IDictionary<string, object>>, Ok<OrderDto>>> GetOrderByOrderIdAsync(
            [FromServices] IStoreApplicationService _storeApplicationService,
            [FromServices] ITypeHelperService _typeHelperService,
            [FromHeader(Name = "Accept")] string? mediaType,
            [FromQuery] string? fields,
            Guid orderId)
        {
            if (!_typeHelperService.TypeHasProperties<OrderDto>(fields))
            {
                return TypedResults.BadRequest();
            }
            var result = await _storeApplicationService.GetOrderByOrderIdAsync(orderId,fields);
            switch (mediaType)
            {
                case "application/vnd.dario.hateoas+json":
                    return TypedResults.Ok(result.LinkedResource);
                default:
                    return TypedResults.Ok(result.ShapedOrder);
            }
        }

        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<OrderDto>, CreatedAtRoute<ExpandoObject>,Ok<OrderDto>>> CreateOrderAsync([FromServices] IStoreApplicationService _storeApplicationService, [FromBody] OrderForCreationDto order)
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

            Guid orderId = (Guid)(result.ShapedOrder as IDictionary<string, object>)["OrderId"];

            return TypedResults.CreatedAtRoute(result.ShapedOrder, $"GetOrder", new { orderId });
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
