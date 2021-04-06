using AutoMapper;
using AutoMapper.QueryableExtensions;
using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.PlantGenera.Queries
{
    public class GetAllPlantGeneraQuery : IRequest<PlantGeneraVm>
    {
    }

    public class GetAllPlantGeneraQueryHandler : IRequestHandler<GetAllPlantGeneraQuery, PlantGeneraVm>
    {
        private readonly IGardenDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPlantGeneraQueryHandler(IGardenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlantGeneraVm> Handle(GetAllPlantGeneraQuery request, CancellationToken cancellationToken)
        {
            return new PlantGeneraVm
            {
                PlantGenera = await _context.PlantGenera
                    .AsNoTracking()
                    .ProjectTo<PlantGenusDto>(_mapper.ConfigurationProvider)
                    .OrderBy(pg => pg.CommonName)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
