using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.Gardens.Commands.DeleteGarden
{
    public class DeleteGardenCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteGardenCommandHandler : IRequestHandler<DeleteGardenCommand>
    {
        private readonly IGardenDbContext _context;

        public DeleteGardenCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGardenCommand request, CancellationToken cancellationToken)
        {
            var gardenToDelete = await _context.Gardens
                .Where(g => g.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            _context.Gardens.Remove(gardenToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
