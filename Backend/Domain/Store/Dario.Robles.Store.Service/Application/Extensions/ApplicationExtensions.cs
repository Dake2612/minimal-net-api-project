using Dario.Robles.Store.Service.Application.Dtos;
using Dario.Robles.Store.Service.Application.Interfaces;
using Dario.Robles.Store.Service.Application.Mappers;
using Dario.Robles.Store.Service.Application.Services;
using Dario.Robles.Store.Service.Application.Validators;
using FluentValidation.AspNetCore;

namespace Dario.Robles.Store.Service.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(OrderMapper));
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OrderForCreationDtoValidator>());
            services.AddTransient<IValidationService, ValidationService>();
            services.AddScoped<IStoreApplicationService, StoreApplicationService>();

        }
    }
}
