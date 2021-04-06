using GardenIssueTracker.Application.Common.Interfaces;
using GardenIssueTracker.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.GardenItems.Commands.AddGardenItem
{
    public class AddGardenItemCommand : IRequest<int>
    {
        public int GardenId { get; set; }
        public string DatePlanted { get; set; }
        public int PlantVarietyId { get; set; }        
    }

    public class AddGardenItemCommandHandler : IRequestHandler<AddGardenItemCommand, int>
    {
        private readonly IGardenDbContext _context;

        public AddGardenItemCommandHandler(IGardenDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddGardenItemCommand request, CancellationToken cancellationToken)
        {
            var gardenItemToAdd = new GardenItem()
            {
                DatePlanted = DateTime.Parse(request.DatePlanted),
                GardenId = request.GardenId,
                PlantVarietyId = request.PlantVarietyId
            };


            await _context.GardenItems.AddAsync(gardenItemToAdd);
            await _context.SaveChangesAsync(cancellationToken);

            return gardenItemToAdd.Id;
        }
    }
}
