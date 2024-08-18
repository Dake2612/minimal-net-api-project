using Dario.Robles.Store.Service.Application.Dtos;
using FluentValidation;

namespace Dario.Robles.Store.Service.Application.Validators
{
    public class OrdersResourceParametersValidator : AbstractValidator<OrdersResourceParameters>
    {
        public OrdersResourceParametersValidator()
        {
            RuleFor(x => x.Fields).Custom((fields, context) =>
            {
                if (!string.IsNullOrEmpty(fields))
                {
                    var fieldList = fields.Split(',');
                    if (!fieldList.Any(f => f.Trim().Equals("OrderId", StringComparison.OrdinalIgnoreCase)))
                    {
                        context.InstanceToValidate.Fields = fields + ",OrderId";
                    }
                }
            });
        }
    }
}
