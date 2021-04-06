using GardenIssueTracker.Application.Common.Interfaces;
using GardenIssueTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.Comments.Commands.AddComment
{
    public class AddCommentCommand : IRequest<int>
    {
        public int GardenItemId { get; set; }
        public string Title { get; set; }
        public bool IsIssue { get; set; }
        public string Description { get; set; }        
    }

    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, int>
    {
        private readonly IGardenDbContext _context;

        public AddCommentCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToAdd = new Comment()
            {
                Title = request.Title,
                GardenItemId = request.GardenItemId,
                IsIssue = request.IsIssue,
                Description = request.Description
            };

            await _context.Comments.AddAsync(commentToAdd);
            await _context.SaveChangesAsync(cancellationToken);

            return commentToAdd.Id;
        }
    }
}
