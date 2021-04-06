using GardenIssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenIssueTracker.Infrastructure.Data.Configurations
{
    public class GardenItemConfiguration : IEntityTypeConfiguration<GardenItem>
    {
        public void Configure(EntityTypeBuilder<GardenItem> builder)
        {
            builder.HasKey(gi => gi.Id);

            builder.Property(gi => gi.DatePlanted)
                .IsRequired();

            builder.HasOne(gi => gi.Garden)
                .WithMany(g => g.GardenItems)
                .HasForeignKey(gi => gi.GardenId)
                .IsRequired();

            builder.HasOne(gi => gi.PlantVariety)
                .WithMany(pv => pv.GardenItems)
                .HasForeignKey(gi => gi.PlantVarietyId)
                .IsRequired();

            builder.HasMany(gi => gi.Comments)
                .WithOne(c => c.GardenItem);
        }
    }
}
