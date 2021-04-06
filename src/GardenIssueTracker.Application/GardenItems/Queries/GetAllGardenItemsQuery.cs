using AutoMapper;
using AutoMapper.QueryableExtensions;
using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.GardenItems.Queries
{
    public class GetAllGardenItemsQuery : IRequest<GardenItemsVm>
    {
        public int GardenId { get; set; }
    }

    public class GetAllGardenItemsQueryHandler : IRequestHandler<GetAllGardenItemsQuery, GardenItemsVm>
    {
        private readonly IGardenDbContext _context;
        private readonly IMapper _mapper;

        public GetAllGardenItemsQueryHandler(IGardenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GardenItemsVm> Handle(GetAllGardenItemsQuery request, CancellationToken cancellationToken)
        {
            return new GardenItemsVm()
            {
                GardenItems = await _context.GardenItems
                    .Where(gi => gi.GardenId == request.GardenId)
                    .ProjectTo<GardenItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
