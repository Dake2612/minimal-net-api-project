using Dario.Robles.Store.Service.Application.Dtos;
using FluentValidation;
using System.Linq;

namespace Dario.Robles.Store.Service.Application.Validators
{
    public class OrderForUpdateDtoValidator : AbstractValidator<OrderForUpdateDto>
    {
        public OrderForUpdateDtoValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
        }
    }
}
