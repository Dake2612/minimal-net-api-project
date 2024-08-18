﻿using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;

namespace Dario.Robles.Store.Service.Infraestructure.http.Helpers.LinksBuilders
{
    public class ItemLinksBuilder : IItemLinksBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;

        public ItemLinksBuilder(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }
        public ItemDto CreateDocumentationLinksForItem(ItemDto item)
        {
            item.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetItemForOrder", new { orderId = item.OrderId, itemId = item.ItemId }), "self", "GET"));
            item.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "DeleteItemForOrder", new { orderId = item.OrderId, itemId = item.ItemId }), "delete_item", "DELETE"));
            item.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "UpdateItemForOrder", new { orderId = item.OrderId, itemId = item.ItemId }), "update_item", "PUT"));
            item.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "PartiallyUpdateItemForOrder", new { orderId = item.OrderId, itemId = item.ItemId }), "partially_update_item", "PATCH"));

            return item;
        }

        public LinkedCollectionResourceWrapperDto<ItemDto> CreateDocumentationLinksForItems(Guid orderId, LinkedCollectionResourceWrapperDto<ItemDto> itemsWrapper)
        {
            itemsWrapper.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetItemsForOrder", new { orderId }), "self", "GET"));

            return itemsWrapper;
        }
    }
}
