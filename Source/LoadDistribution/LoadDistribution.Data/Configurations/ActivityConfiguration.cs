using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoadDistribution.Data.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
      public void Configure(EntityTypeBuilder<Activity> builder)
      {
            builder.HasKey(k => k.Id);

            builder.Property(k => k.Name).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Created).HasConversion(new DateTimeOffsetToBinaryConverter());
            builder.Property(p => p.Updated).HasConversion(new DateTimeOffsetToBinaryConverter());

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p!.Activities)
                .HasForeignKey(fk => fk.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
      }
}
