using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;

namespace Dario.Robles.Store.Service.Infraestructure.http.Helpers.LinksBuilders
{
    public interface IItemLinksBuilder
    {
        ItemDto CreateDocumentationLinksForItem(ItemDto item);
        LinkedCollectionResourceWrapperDto<ItemDto> CreateDocumentationLinksForItems(Guid orderId, LinkedCollectionResourceWrapperDto<ItemDto> itemsWrapper);
    }
}
