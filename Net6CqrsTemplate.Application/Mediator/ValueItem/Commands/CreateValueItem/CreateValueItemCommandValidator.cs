namespace Net6CqrsTemplate.Application.Mediator.ValueItem.Commands.CreateValueItem;

using FluentValidation;

/// <summary>
/// Validation rules for CreateValueItemCommand.
/// </summary>
public class CreateValueItemCommandValidator : AbstractValidator<CreateValueItemCommand>
{
    public CreateValueItemCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");
    }
}