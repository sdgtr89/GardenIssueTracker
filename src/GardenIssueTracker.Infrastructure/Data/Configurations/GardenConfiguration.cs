using GardenIssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenIssueTracker.Infrastructure.Data.Configurations
{
    public class GardenConfiguration : IEntityTypeConfiguration<Garden>
    {
        public void Configure(EntityTypeBuilder<Garden> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(g => g.StartDate)
                .IsRequired();

            builder.HasMany(g => g.GardenItems)
                .WithOne(gi => gi.Garden);
        }
    }
}
