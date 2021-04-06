using FluentValidation;

namespace GardenIssueTracker.Application.Gardens.Commands.AddGarden
{
    public class AddGardenCommandValidator : AbstractValidator<AddGardenCommand>
    {
        public AddGardenCommandValidator()
        {
            RuleFor(pv => pv.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be left blank.")
                .MaximumLength(30)
                .WithMessage("{PropertyName} cannot exceed {MaxLength} characters");

            RuleFor(pv => pv.StartDate)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be left blank.");
        }
    }
}
