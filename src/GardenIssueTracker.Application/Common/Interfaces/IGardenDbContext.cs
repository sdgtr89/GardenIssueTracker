using GardenIssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GardenIssueTracker.Application.Common.Interfaces
{
    public interface IGardenDbContext
    {
        public DbSet<PlantGenus> PlantGenera { get; set; }
        public DbSet<PlantVariety> PlantVarieties { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<GardenItem> GardenItems { get; set; }
        public DbSet<Comment> Comments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
