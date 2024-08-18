using AutoMapper;
using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Domain.Orders.Entities;

namespace Dario.Robles.Store.Service.Application.Mappers
{
    public class ItemMapper : Profile
    {
        public ItemMapper()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<ItemForCreationDto, Item>();
            CreateMap<ItemForUpdateDto, Item>();
            CreateMap<Item, ItemForUpdateDto>();
        }
    }
}
