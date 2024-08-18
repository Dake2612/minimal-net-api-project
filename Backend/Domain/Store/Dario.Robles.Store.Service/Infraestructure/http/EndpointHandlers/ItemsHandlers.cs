using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Application.Interfaces;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dario.Robles.Store.Service.Infraestructure.http.EndpointHandlers
{
    public class ItemsHandlers
    {
        public static async Task<Results<NotFound, Ok<LinkedCollectionResourceWrapperDto<ItemDto>>>> GetItemsForOrderAsync(
            [FromServices] IStoreApplicationService _storeApplicationService,
            Guid orderId
        )
        {
            if (!await _storeApplicationService.OrderExitsAsync(orderId))
            {
                return TypedResults.NotFound();
            }

            var result = await _storeApplicationService.GetItemsForOrderAsync(orderId);

            return TypedResults.Ok(result.LinkedCollectionResource);
        }
        public static async Task<Results<NotFound, Ok<ItemDto>>> GetItemByItemIdForOrderAsync(
            [FromServices] IStoreApplicationService _storeApplicationService,
            Guid orderId,
            Guid itemId
        )
        {
            if (!await _storeApplicationService.OrderExitsAsync(orderId))
            {
                return TypedResults.NotFound();
            }

            var result = await _storeApplicationService.GetItemByItemIdForOrderAsync(orderId, itemId);
            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result.LinkedResource);
        }
        public static async Task<Results<BadRequest, NotFound, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<ItemDto>>> CreateItemForOrderAsync(
            [FromServices] IStoreApplicationService _storeApplicationService,
            Guid orderId,
            [FromBody] ItemForCreationDto item
        )
        {
            if (item == null)
            {
                return TypedResults.BadRequest();
            }

            if (!await _storeApplicationService.OrderExitsAsync(orderId))
            {
                return TypedResults.NotFound();
            }

            var result = await _storeApplicationService.CreateItemForOrderAsync(orderId, item);

            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            return TypedResults.CreatedAtRoute(result.LinkedResource, $"GetItemForOrder", new { orderId, itemId = result.LinkedResource.ItemId });
        }
        public static async Task<Results<NotFound, NoContent>> DeleteItemForOrderAsync(
            [FromServices] IStoreApplicationService _storeApplicationService,
            Guid orderId,
            Guid itemId
        )
        {
            var result = await _storeApplicationService.DeleteItemForOrderAsync(orderId, itemId);

            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.NoContent();
        }
        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<ItemDto>, UnprocessableEntity<List<ValidationResult>>>> UpdateItemForOrderAsync(
            [FromServices] IStoreApplicationService _storeApplicationService,
            [FromBody] ItemForUpdateDto item,
            Guid orderId,
            Guid itemId
        )
        {
            if (item == null)
            {
                return TypedResults.BadRequest();
            }

            if (!await _storeApplicationService.OrderExitsAsync(orderId))
            {
                return TypedResults.NotFound();
            }

            var result = await _storeApplicationService.UpdateItemForOrderAsync(orderId, itemId, item);

            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }
            else
            {
                if (result.Success && result.ItemUpserted != null)
                {
                    return TypedResults.CreatedAtRoute(result.ItemUpserted, "UpdateItemForOrder", new { orderId, itemId = result.ItemUpserted.ItemId });
                }
            }

            return TypedResults.NoContent();
        }

        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<ItemDto>, UnprocessableEntity<List<ValidationResult>>>> PartiallyUpdateItemForOrderAsync(
            [FromServices] IStoreApplicationService _storeApplicationService,
            [FromBody] JsonPatchDocument<ItemForUpdateDto> patchDoc,
            Guid orderId,
            Guid itemId
        )
        {
            if (patchDoc == null)
            {
                return TypedResults.BadRequest();
            }

            if (!await _storeApplicationService.OrderExitsAsync(orderId))
            {
                return TypedResults.NotFound();
            }

            var result = await _storeApplicationService.PartiallyUpdateItemForOrder(orderId, itemId, patchDoc);

            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }
            else
            {
                if (result.ItemUpserted != null)
                {
                    return TypedResults.CreatedAtRoute(result.ItemUpserted, "GetItemForOrder", new { orderId, itemId = result.ItemUpserted.ItemId });
                }
            }

            return TypedResults.NoContent();
        }
    }
}
