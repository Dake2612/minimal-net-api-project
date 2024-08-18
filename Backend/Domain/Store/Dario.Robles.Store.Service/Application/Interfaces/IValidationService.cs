using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Application.Validators;
using FluentValidation.Results;

namespace Dario.Robles.Store.Service.Application.Interfaces
{
    public interface IValidationService
    {
        ValidationResult ValidateOrderCreate(OrderForCreationDto dto);
        ValidationResult ValidateOrderUpdate(OrderForUpdateDto dto);
        ValidationResult ValidateOrderResourceParameters(OrdersResourceParameters resource);
        ValidationResult ValidateItemCreation(ItemForCreationDto dto);
        ValidationResult ValidateItemUpdate(ItemForUpdateDto dto);
    }
}
