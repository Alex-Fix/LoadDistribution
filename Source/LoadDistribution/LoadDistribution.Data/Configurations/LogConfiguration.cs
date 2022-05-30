using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoadDistribution.Data.Configurations;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
      public void Configure(EntityTypeBuilder<Log> builder)
      {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Message).IsRequired().HasMaxLength(512);
            builder.Property(p => p.Details).HasMaxLength(4096);
            builder.Property(p => p.ExceptionType).HasMaxLength(256);
            builder.Property(p => p.Created).HasConversion(new DateTimeOffsetToBinaryConverter());
      }
}
