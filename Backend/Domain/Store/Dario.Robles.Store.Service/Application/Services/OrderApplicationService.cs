using Azure.Core;
using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Application.Interfaces;
using Dario.Robles.Store.Service.Domain.Orders.Entities;
using Dario.Robles.Store.Service.Infraestructure.http.Results.Orders;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Dario.Robles.Store.Service.Application.Services
{
    public partial class StoreApplicationService : IStoreApplicationService
    {
        public async Task<GetOrdersResult> GetOrdersAsync(OrdersResourceParameters ordersResourceParameters)
        {
            GetOrdersResult result = new();
            _validationService.ValidateOrderResourceParameters(ordersResourceParameters);
            var ordersFromRepo = await _unitOfWork.Orders.GetOrdersAsync(ordersResourceParameters);
            var orders = _mapper.Map<IEnumerable<OrderDto>>(ordersFromRepo);
            result.ShapedOrders = orders.ShapeData(ordersResourceParameters.Fields);
            result.PaginationMetadata = _storeLinksBuilder.GetPaginationMetadata(ordersFromRepo, ordersResourceParameters);
            var links = _storeLinksBuilder.CreatePagedLinksForOrders(ordersResourceParameters, ordersFromRepo.HasNext, ordersFromRepo.HasPrevious);
            var shapedOrdersWithLinks = _storeLinksBuilder.CreateDocumentationLinksForOrderShapeData(result.ShapedOrders, ordersResourceParameters);
            result.LinkedCollectionResource = new LinkedCollectionResource { Value = shapedOrdersWithLinks, Links = links };
            return result;
        }

        public async Task<GetOrderByOrderIdResult> GetOrderByOrderIdAsync(Guid orderId, string fields)
        {
            GetOrderByOrderIdResult result = new();
            var orderFromRepo = await _unitOfWork.Orders.GetOrderAsync(orderId);
            if(orderFromRepo == null)
            {
                return null;
            }
            var order = _mapper.Map<OrderDto>(orderFromRepo);
            result.ShapedOrder = order.ShapeData(fields);

            var links = _storeLinksBuilder.CreateDocumentationLinksForOrder(orderId, fields);
            result.LinkedResource = new Dictionary<string, object>(result.ShapedOrder);
            result.LinkedResource.Add("links", links);

            return result;
        }

        public async Task<CreateOrderResult> CreateOrderAsync(OrderForCreationDto order)
        {
            CreateOrderResult result = new();
            var validationResult = _validationService.ValidateOrderCreate(order);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var orderEntity = _mapper.Map<Order>(order);
            await _unitOfWork.Orders.AddOrderAsync(orderEntity);

            if(!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an Order failed on save.");
            }
            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            result.ShapedOrder = orderToReturn.ShapeData(null);
            result.Success = true;

            var links = _storeLinksBuilder.CreateDocumentationLinksForOrder(orderToReturn.OrderId, null);
            result.LinkedResource = new Dictionary<string, object>(result.ShapedOrder);
            result.LinkedResource.Add("links", links);

            return result;
        }

        public async Task<bool?> DeleteOrderAsync(Guid orderId)
        {
            var orderFromRepo = await _unitOfWork.Orders.GetOrderAsync(orderId);
            if(orderFromRepo == null)
            {
                return null;
            }

            await _unitOfWork.Orders.DeleteOrderAsync(orderFromRepo);

            if(!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting order {orderId} failed on sale.");
            }

            return true;
        }

        public async Task<UpdateOrderResult> UpdateOrderAsync(Guid orderId, OrderForUpdateDto order)
        {
            UpdateOrderResult result = new();
            var validationResult = _validationService.ValidateOrderUpdate(order);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var orderFromRepo = await _unitOfWork.Orders.GetOrderAsync(orderId);
            if(orderFromRepo == null)
            {
                var orderToAdd = _mapper.Map<Order>(order);
                orderToAdd.OrderId = orderId;

                await _unitOfWork.Orders.AddOrderAsync(orderToAdd);

                if(!await _unitOfWork.SaveAsync())
                {
                    throw new Exception($"Upserting order {orderId} failed on save.");
                }

                result.OrderUpserted = _mapper.Map<OrderDto>(orderToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(order, orderFromRepo);
            await _unitOfWork.Orders.UpdateOrderAsync(orderFromRepo);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Updating order {orderId} failed on save.");
            }

            result.Success = true;
            return result;
        }

        public async Task<bool> OrderExitsAsync(Guid orderId)
        {
            return await _unitOfWork.Orders.OrderExists(orderId);
        }
    }
}
