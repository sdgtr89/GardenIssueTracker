using GardenIssueTracker.Application.Common.Interfaces;
using GardenIssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GardenIssueTracker.Infrastructure.Data
{
    public class GardenDbContext : DbContext, IGardenDbContext
    {
        public GardenDbContext(DbContextOptions<GardenDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlantGenus> PlantGenera { get; set; }
        public DbSet<PlantVariety> PlantVarieties { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<GardenItem> GardenItems { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
