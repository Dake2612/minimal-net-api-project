using AutoMapper;
using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Domain.Orders.Entities;

namespace Dario.Robles.Store.Service.Application.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper() 
        {
            CreateMap<Order, OrderDto>();

            CreateMap<OrderForCreationDto, Order>();

            CreateMap<OrderForUpdateDto, Order>();

            CreateMap<Order, OrderForUpdateDto>();
        }
    }
}
