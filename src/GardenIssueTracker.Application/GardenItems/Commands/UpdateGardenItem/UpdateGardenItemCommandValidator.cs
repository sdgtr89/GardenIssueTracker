using FluentValidation;

namespace GardenIssueTracker.Application.GardenItems.Commands.UpdateGardenItem
{
    public class UpdateGardenItemCommandValidator : AbstractValidator<UpdateGardenItemCommand>
    {
        public UpdateGardenItemCommandValidator()
        {
            RuleFor(pv => pv.DatePlanted)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be left blank.");

            RuleFor(pv => pv.PlantVarietyId)
                .NotEmpty()
                .WithMessage("A Garden Item cannot be created without a Plant Variety.");
        }
    }
}
