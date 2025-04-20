using FluentValidation;

namespace WebApi.Impl.Validations
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(id => id)
                .GreaterThan(0).WithMessage("Id must be greater than zero.");
        }
    }
}
