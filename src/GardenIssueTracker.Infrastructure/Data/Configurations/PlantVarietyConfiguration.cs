using GardenIssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenIssueTracker.Infrastructure.Data.Configurations
{
    public class PlantVarietyConfiguration : IEntityTypeConfiguration<PlantVariety>
    {
        public void Configure(EntityTypeBuilder<PlantVariety> builder)
        {
            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(pv => pv.Name)
                .IsUnique();

            builder.HasOne(pv => pv.PlantGenus)
                .WithMany(pg => pg.PlantVarieties)
                .HasForeignKey(pv => pv.PlantGenusId)
                .IsRequired();

            builder.HasMany(pv => pv.GardenItems)
                .WithOne(gi => gi.PlantVariety);
        }
    }
}
