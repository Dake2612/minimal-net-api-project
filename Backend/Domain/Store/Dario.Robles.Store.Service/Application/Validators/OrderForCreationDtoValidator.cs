using Dario.Robles.Store.Service.Application.Dtos;
using FluentValidation;

namespace Dario.Robles.Store.Service.Application.Validators
{
    public class OrderForCreationDtoValidator : AbstractValidator<OrderForCreationDto>
    {
        public OrderForCreationDtoValidator() 
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
        }
    }
}
