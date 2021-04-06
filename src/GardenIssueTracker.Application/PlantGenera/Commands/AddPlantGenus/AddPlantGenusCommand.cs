using GardenIssueTracker.Application.Common.Interfaces;
using GardenIssueTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.PlantGenera.Commands.AddPlantGenus
{
    public class AddPlantGenusCommand : IRequest<int>
    {
        public string CommonName { get; set; }
        public string ScientificName { get; set; }       
    }

    public class AddPlantGenusCommandHandler : IRequestHandler<AddPlantGenusCommand, int>
    {
        private readonly IGardenDbContext _context;

        public AddPlantGenusCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddPlantGenusCommand request, CancellationToken cancellationToken)
        {
            var plantGenus = new PlantGenus()
            {
                CommonName = request.CommonName,
                ScientificName = request.ScientificName
            };

            await _context.PlantGenera.AddAsync(plantGenus);
            await _context.SaveChangesAsync(cancellationToken);

            return plantGenus.Id;

        }
    }
}
