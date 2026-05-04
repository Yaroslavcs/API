using FluentValidation;
using LibraryApi.BLL.DTOs;

namespace LibraryApi.BLL.Validators;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(300);
        RuleFor(x => x.Author).NotEmpty().MaximumLength(200);
        RuleFor(x => x.YearPublished).InclusiveBetween(1000, 2100);
    }
}
