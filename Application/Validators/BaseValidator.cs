using FluentValidation;

namespace Application.Validators
{
    public static class BaseValidator
    {
        public static IRuleBuilderOptions<T, Guid> IsValidId<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("Id is required").NotEqual(Guid.Empty).WithMessage("Invalid Id format");
        }
    }
}
