using GardenIssueTracker.Application.Common.Interfaces;
using GardenIssueTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.PlantVarieties.Commands.AddPlantVariety
{
    public class AddPlantVarietyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int PlantGenusId { get; set; }        
    }

    public class AddPlantVarietyCommandHandler : IRequestHandler<AddPlantVarietyCommand, int>
    {
        private readonly IGardenDbContext _context;

        public AddPlantVarietyCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddPlantVarietyCommand request, CancellationToken cancellationToken)
        {
            var plantVariety = new PlantVariety()
            {
                Name = request.Name,
                PlantGenusId = request.PlantGenusId
            };

            await _context.PlantVarieties.AddAsync(plantVariety);
            await _context.SaveChangesAsync(cancellationToken);

            return plantVariety.Id;
        }
    }
}
