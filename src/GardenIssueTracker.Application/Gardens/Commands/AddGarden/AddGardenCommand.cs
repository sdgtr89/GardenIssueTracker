using GardenIssueTracker.Application.Common.Interfaces;
using GardenIssueTracker.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.Gardens.Commands.AddGarden
{
    public class AddGardenCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class AddGardenCommandHandler : IRequestHandler<AddGardenCommand, int>
    {
        private readonly IGardenDbContext _context;

        public AddGardenCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddGardenCommand request, CancellationToken cancellationToken)
        {
            var garden = new Garden()
            {
                Name = request.Name,
                StartDate = request.StartDate
            };

            await _context.Gardens.AddAsync(garden);
            await _context.SaveChangesAsync(cancellationToken);

            return garden.Id;
        }

    }
}
