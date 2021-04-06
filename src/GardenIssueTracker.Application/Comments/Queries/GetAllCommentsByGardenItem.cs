using AutoMapper;
using AutoMapper.QueryableExtensions;
using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.Comments.Queries
{
    public class GetAllCommentsByGardenItem : IRequest<ComentsDto>
    {
        public int GardenItemId { get; set; }       
    }

    public class GetAllCommentsQueryByGardenItemHandler : IRequestHandler<GetAllCommentsByGardenItem, ComentsDto>
    {
        private readonly IGardenDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCommentsQueryByGardenItemHandler(IGardenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ComentsDto> Handle(GetAllCommentsByGardenItem request, CancellationToken cancellationToken)
        {
            return new ComentsDto()
            {
                Comments = await _context.Comments
                    .Where(c => c.GardenItemId == request.GardenItemId)
                    .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync()
            };
        }
    }
}
