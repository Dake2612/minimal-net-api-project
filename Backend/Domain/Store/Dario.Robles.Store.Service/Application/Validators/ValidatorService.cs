using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Dario.Robles.Store.Service.Application.Validators
{
    public class ValidationService : IValidationService
    {
        private readonly IValidator<OrderForCreationDto> _orderCreationValidator;
        private readonly IValidator<OrderForUpdateDto> _orderUpdateValidator;

        public ValidationService(
            IValidator<OrderForCreationDto> orderCreationValidator, IValidator<OrderForUpdateDto> orderUpdateValidator)
        {
            _orderCreationValidator = orderCreationValidator;
            _orderUpdateValidator = orderUpdateValidator;
        }

        public ValidationResult ValidateOrderCreate(OrderForCreationDto dto)
        {
            return _orderCreationValidator.Validate(dto);
        }
        public ValidationResult ValidateOrderUpdate(OrderForUpdateDto dto)
        {
            return _orderUpdateValidator.Validate(dto);
        }
    }
}
