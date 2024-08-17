using Dario.Robles.Store.Service.Application.Dtos;
using FluentValidation.Results;

namespace Dario.Robles.Store.Service.Application.Interfaces
{
    public interface IValidationService
    {
        ValidationResult ValidateOrderCreate(OrderForCreationDto dto);
        ValidationResult ValidateOrderUpdate(OrderForUpdateDto dto);
    }
}
