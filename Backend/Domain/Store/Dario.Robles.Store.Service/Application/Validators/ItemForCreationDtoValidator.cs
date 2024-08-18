using Dario.Robles.Store.Service.Application.Dtos;
using FluentValidation;

namespace Dario.Robles.Store.Service.Application.Validators
{
    public class ItemForCreationDtoValidator : ItemForManipulationDtoValidator<ItemForCreationDto>
    {
        public ItemForCreationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0)
                .WithMessage("The quantity must be greater than zero");
        }
    }
}
