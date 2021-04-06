using AutoMapper;
using AutoMapper.QueryableExtensions;
using GardenIssueTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.PlantVarieties.Queries
{
    public class GetAllPlantVarietiesQuery : IRequest<PlantVarietiesVm> 
    {
    }

    public class GetAllPlantVarietiesQueryHandler : IRequestHandler<GetAllPlantVarietiesQuery, PlantVarietiesVm>
    {
        private readonly IGardenDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPlantVarietiesQueryHandler(IGardenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlantVarietiesVm> Handle(GetAllPlantVarietiesQuery request, CancellationToken cancellationToken)
        {
            return new PlantVarietiesVm()
            {
                PlantVarieties = await _context.PlantVarieties
                    .ProjectTo<PlantVarietyDto>(_mapper.ConfigurationProvider)
                    .OrderBy(pv => pv.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
