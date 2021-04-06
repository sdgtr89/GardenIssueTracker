using GardenIssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenIssueTracker.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.IsIssue)
                .IsRequired();

            builder.Property(c => c.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(c => c.GardenItem)
                .WithMany(gi => gi.Comments)
                .HasForeignKey(c => c.GardenItemId)
                .IsRequired();
        }
    }
}
