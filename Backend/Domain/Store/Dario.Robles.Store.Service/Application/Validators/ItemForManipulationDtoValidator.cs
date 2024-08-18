using Dario.Robles.Store.Service.Application.Dtos;
using FluentValidation;

namespace Dario.Robles.Store.Service.Application.Validators
{
    public class ItemForManipulationDtoValidator<T> : AbstractValidator<T> where T : ItemForManipulationDto
    {
        public ItemForManipulationDtoValidator()
        {

        }
    }
}
