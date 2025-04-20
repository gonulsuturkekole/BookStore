using FluentValidation;
using WebApi.Impl.Model;

namespace WebApi.Impl.Validations
{
    public class UpdateBookModelValidator : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.PageCount)
                .GreaterThan(0).WithMessage("Page count must be greater than zero.");

            RuleFor(x => x.GenreId)
                .GreaterThan(0).WithMessage("A valid genre must be selected.");

            RuleFor(x => x.PublishDate)
                .LessThan(DateTime.Now).WithMessage("Publish date cannot be in the future.");
        }
    }
}
