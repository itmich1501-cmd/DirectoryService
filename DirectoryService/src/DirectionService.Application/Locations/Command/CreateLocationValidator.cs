using FluentValidation;

namespace DirectionService.Application.Locations.Command;

public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название не может быть пустым.")
            .MaximumLength(5000).WithMessage("Текст не валидный");
    }
}