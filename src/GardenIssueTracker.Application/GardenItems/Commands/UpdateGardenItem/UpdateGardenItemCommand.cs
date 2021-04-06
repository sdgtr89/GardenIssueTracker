using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.GardenItems.Commands.UpdateGardenItem
{
    public class UpdateGardenItemCommand : IRequest
    {
        public int Id { get; set; }
        public string DatePlanted { get; set; }
        public int PlantVarietyId { get; set; }        
    }

    public class UpdateGardenItemCommandHandler : IRequestHandler<UpdateGardenItemCommand>
    {
        private readonly IGardenDbContext _context;

        public UpdateGardenItemCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGardenItemCommand request, CancellationToken cancellationToken)
        {
            var gardenItemToUpdate = await _context.GardenItems
                .Where(gi => gi.Id == request.Id)
                .SingleOrDefaultAsync();

            gardenItemToUpdate.DatePlanted = DateTime.Parse(request.DatePlanted);
            gardenItemToUpdate.PlantVarietyId = request.PlantVarietyId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
