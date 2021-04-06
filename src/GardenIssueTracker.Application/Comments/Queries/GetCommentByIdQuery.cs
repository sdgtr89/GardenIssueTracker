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
    public class GetCommentByIdQuery : IRequest<CommentDto>
    {
        public int Id { get; set; }        
    }

    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly IGardenDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(IGardenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Comments
                .Where(c => c.Id == request.Id)
                .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
