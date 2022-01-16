using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LoadDistribution.Data.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.CreatedUtc).IsRequired();
            builder.Property(p => p.Message).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Details).HasMaxLength(4096);
            builder.Property(p => p.TypeStr).IsRequired().HasMaxLength(128);
            builder.Property(p => p.ExceptionType).HasMaxLength(256);
        }
    }
}
