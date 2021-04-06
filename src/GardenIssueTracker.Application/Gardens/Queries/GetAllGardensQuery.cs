using AutoMapper;
using AutoMapper.QueryableExtensions;
using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.Gardens.Queries
{
    public class GetAllGardensQuery : IRequest<GardensVm>
    {
    }

    public class GetAllGardensQueryHandler : IRequestHandler<GetAllGardensQuery, GardensVm>
    {
        private readonly IGardenDbContext _context;
        private readonly IMapper _mapper;

        public GetAllGardensQueryHandler(IGardenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GardensVm> Handle(GetAllGardensQuery request, CancellationToken cancellationToken)
        {
            return new GardensVm()
            {
                Gardens = await _context.Gardens
                    .ProjectTo<GardenDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
