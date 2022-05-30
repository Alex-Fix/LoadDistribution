using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoadDistribution.Data.Configurations;

public class UniversityConfiguration : IEntityTypeConfiguration<University>
{
      public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<University> builder)
      {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Created).HasConversion(new DateTimeOffsetToBinaryConverter());
            builder.Property(p => p.Updated).HasConversion(new DateTimeOffsetToBinaryConverter());

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p!.Universities)
                .HasForeignKey(fk => fk.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
      }
}
