namespace StudentAffairs.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var arg in context.ActionArguments.Values)
            {
                if (arg is null) continue;

                var validatorType = typeof(IValidator<>).MakeGenericType(arg.GetType());

                var validator = context.HttpContext.RequestServices.GetService(validatorType);

                if (validator is not null)
                {
                    var validationContext = new ValidationContext<object>(arg);
                    var result = await ((IValidator)validator).ValidateAsync(validationContext);
                    if (!result.IsValid)
                    {
                        throw new FluentValidation.ValidationException(result.Errors);
                    }
                }
            }
            await next();
        }
    }
}