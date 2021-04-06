using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }        
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IGardenDbContext _context;

        public DeleteCommentCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToDelete = await _context.Comments.FindAsync(request.Id);
            _context.Comments.Remove(commentToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
