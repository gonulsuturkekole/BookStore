using FluentValidation;
using WebApi.Impl.Model;

public class CreateBookModelValidator : AbstractValidator<CreateBookModel>
{
    public CreateBookModelValidator()
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
            .NotEmpty().WithMessage("Publish date is required.")
            .LessThan(DateTime.Now).WithMessage("Publish date cannot be in the future.");
    }
}
