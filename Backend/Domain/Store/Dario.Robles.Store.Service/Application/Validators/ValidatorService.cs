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
        private readonly IValidator<OrdersResourceParameters> _orderResourceParametersValidator;

        private readonly IValidator<ItemForCreationDto> _itemCreationValidator;
        private readonly IValidator<ItemForUpdateDto> _itemUpdateValidator;

        public ValidationService(
            IValidator<OrderForCreationDto> orderCreationValidator, 
            IValidator<OrderForUpdateDto> orderUpdateValidator, 
            IValidator<OrdersResourceParameters> orderResourceParametersValidator,
            IValidator<ItemForCreationDto> itemCreationValidator,
            IValidator<ItemForUpdateDto> itemUpdateValidator)
        {
            _orderCreationValidator = orderCreationValidator;
            _orderUpdateValidator = orderUpdateValidator;
            _orderResourceParametersValidator = orderResourceParametersValidator;
            _itemCreationValidator = itemCreationValidator;
            _itemUpdateValidator = itemUpdateValidator;
        }

        public ValidationResult ValidateOrderCreate(OrderForCreationDto dto)
        {
            return _orderCreationValidator.Validate(dto);
        }
        public ValidationResult ValidateOrderUpdate(OrderForUpdateDto dto)
        {
            return _orderUpdateValidator.Validate(dto);
        }
        public ValidationResult ValidateOrderResourceParameters(OrdersResourceParameters resource)
        {
            return _orderResourceParametersValidator.Validate(resource);
        }
        public ValidationResult ValidateItemCreation(ItemForCreationDto dto)
        {
            return _itemCreationValidator.Validate(dto);
        }
        public ValidationResult ValidateItemUpdate(ItemForUpdateDto dto)
        {
            return _itemUpdateValidator.Validate(dto);
        }
    }
}
