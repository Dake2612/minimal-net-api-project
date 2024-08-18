using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;

namespace Dario.Robles.Store.Service.Infraestructure.http.Results.Items
{
    public class GetItemsForOrderResult
    {
        public LinkedCollectionResourceWrapperDto<ItemDto> LinkedCollectionResource { get; set; }
    }
}
