using FluentValidation;
using GardenIssueTracker.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.PlantVarieties.Commands.AddPlantVariety
{
    public class AddPlantVarietyCommandValidator : AbstractValidator<AddPlantVarietyCommand>
    {
        private readonly IGardenDbContext _context;

        public AddPlantVarietyCommandValidator(IGardenDbContext context)
        {
            _context = context;
        }

        public AddPlantVarietyCommandValidator()
        {
            RuleFor(pv => pv.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be left blank.")
                .MaximumLength(30)
                .WithMessage("{PropertyName} cannot exceed {MaxLength} characters")
                .MustAsync(IsUniqueName).WithMessage("{PropertyName} must be unique");

            RuleFor(pv => pv.PlantGenusId)
                .NotEmpty()
                .WithMessage("A Plant Genus must be provided.");
        }

        private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.PlantVarieties.AllAsync(pv => pv.Name != name);
        }
    }
}
