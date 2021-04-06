using FluentValidation;

namespace GardenIssueTracker.Application.Gardens.Commands.UpdateGarden
{
    public class UpdateGardenCommandValidator : AbstractValidator<UpdateGardenCommand>
    {
        public UpdateGardenCommandValidator()
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
