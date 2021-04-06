using FluentValidation;
using GardenIssueTracker.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.PlantGenera.Commands.AddPlantGenus
{
    public class AddPlantGenusCommandValidator : AbstractValidator<AddPlantGenusCommand>
    {
        private readonly IGardenDbContext _context;

        public AddPlantGenusCommandValidator(IGardenDbContext context)
        {
            _context = context;
        }

        public AddPlantGenusCommandValidator()
        {
            RuleFor(pg => pg.CommonName)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be left blank.")
                .MaximumLength(24)
                .WithMessage("{PropertyName} cannot exceed {MaxLength} characters")
                .MustAsync(IsUniqueCommonName)
                .WithMessage("Any entry mathces the value entered. Value must be unique");

            RuleFor(pg => pg.ScientificName)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be left blank.")           
                .MaximumLength(24)
                .WithMessage("{PropertyName} cannot exceed {MaxLength} characters")
                .MustAsync(IsUniqueScientificName)
                .WithMessage("Any entry mathces the value entered. Value must be unique");
        }

        private async Task<bool> IsUniqueCommonName(string commonName, CancellationToken cancellationToken)
        {
            return await _context.PlantGenera.AllAsync(pg => pg.CommonName != commonName);
        }

        private async Task<bool> IsUniqueScientificName(string scientificName, CancellationToken cancellationToken)
        {
            return await _context.PlantGenera.AllAsync(pg => pg.ScientificName != scientificName);
        }
    }
}
