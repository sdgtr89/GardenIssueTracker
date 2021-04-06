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
    public class GetPlantVarietyByIdQuery : IRequest<PlantVarietyDto>
    {
        public int Id { get; set; }
    }

    public class GetPlantVarietyByIdQueryHandler : IRequestHandler<GetPlantVarietyByIdQuery, PlantVarietyDto>
    {
        private readonly IGardenDbContext _context;
        private readonly IMapper _mapper;

        public GetPlantVarietyByIdQueryHandler(IGardenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlantVarietyDto> Handle(GetPlantVarietyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.PlantVarieties
                .Where(pv => pv.Id == request.Id)
                .ProjectTo<PlantVarietyDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

        }
    }
}
