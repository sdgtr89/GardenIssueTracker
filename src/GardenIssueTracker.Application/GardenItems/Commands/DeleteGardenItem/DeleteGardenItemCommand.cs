using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.GardenItems.Commands.DeleteGardenItem
{
    public class DeleteGardenItemCommand : IRequest
    {
        public int Id { get; set; }       
    }

    public class DeleteGardenItemCommandHandler : IRequestHandler<DeleteGardenItemCommand>
    {
        private readonly IGardenDbContext _context;

        public DeleteGardenItemCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGardenItemCommand request, CancellationToken cancellationToken)
        {
            var gardenItemToDelete = await _context.GardenItems.FindAsync(request.Id);
            _context.GardenItems.Remove(gardenItemToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
