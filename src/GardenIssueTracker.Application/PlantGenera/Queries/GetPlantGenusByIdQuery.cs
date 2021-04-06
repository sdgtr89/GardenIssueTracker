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
    public class GetPlantGenusByIdQuery : IRequest<PlantGenusDto>
    {
        public int Id { get; set; }
    }

    public class GetPlantGenusByIdQueryHandler : IRequestHandler<GetPlantGenusByIdQuery, PlantGenusDto>
    {
        private readonly IGardenDbContext _context;
        private readonly IMapper _mapper;

        public GetPlantGenusByIdQueryHandler(IGardenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlantGenusDto> Handle(GetPlantGenusByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
            {
                return null;
            }

            var plantGenus = await _context.PlantGenera
                    .Where(pg => pg.Id == request.Id)
                    .ProjectTo<PlantGenusDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

            return plantGenus;
        }
    }
}
