using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;

namespace Dario.Robles.Store.Service.Application.Dtos
{
    public class ItemDto : LinkedResourceBaseDto
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}
