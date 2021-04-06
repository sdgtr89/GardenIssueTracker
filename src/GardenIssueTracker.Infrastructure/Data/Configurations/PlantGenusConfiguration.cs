using GardenIssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenIssueTracker.Infrastructure.Data.Configurations
{
    public class PlantGenusConfiguration : IEntityTypeConfiguration<PlantGenus>
    {
        public void Configure(EntityTypeBuilder<PlantGenus> builder)
        {
            builder.HasKey(pg => pg.Id);

            builder.Property(pg => pg.ScientificName)
                .HasMaxLength(24)
                .IsRequired();

            builder.HasIndex(pg => pg.ScientificName)
                .IsUnique();

            builder.Property(pg => pg.CommonName)
                .HasMaxLength(24)
                .IsRequired();

            builder.HasIndex(pg => pg.CommonName)
                .IsUnique();

            builder.HasMany(pg => pg.PlantVarieties)
                .WithOne(pv => pv.PlantGenus);
        }
    }
}
