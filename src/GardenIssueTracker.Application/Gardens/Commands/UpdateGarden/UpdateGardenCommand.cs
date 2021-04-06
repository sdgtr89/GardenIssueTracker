using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.Gardens.Commands.UpdateGarden
{
    public class UpdateGardenCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class UpdateGardenCommandHandler : IRequestHandler<UpdateGardenCommand>
    {
        private readonly IGardenDbContext _context;

        public UpdateGardenCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGardenCommand request, CancellationToken cancellationToken)
        {
            var gardenToUpdate = await _context.Gardens
                .Where(g => g.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            gardenToUpdate.Name = request.Name;
            gardenToUpdate.StartDate = request.StartDate;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
