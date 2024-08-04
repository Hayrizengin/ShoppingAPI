using Microsoft.AspNetCore.Mvc.Filters;
using ShoppingAPI.Api.Validation.FluentValidation;

namespace ShoppingAPI.Api.Aspects
{
    public class ValidationFilter : Attribute, IAsyncActionFilter
    {
        private readonly Type _validatorType;

        public ValidationFilter(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ValidationHelper.Validate(_validatorType, context.ActionArguments.Values.ToArray());

            await next();
        }
    }
}
