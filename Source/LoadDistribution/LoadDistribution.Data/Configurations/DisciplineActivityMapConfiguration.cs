using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoadDistribution.Data.Configurations
{
    public class DisciplineActivityMapConfiguration : IEntityTypeConfiguration<DisciplineActivityMap>
    {
        public void Configure(EntityTypeBuilder<DisciplineActivityMap> builder)
        {
            builder.ToTable("DisciplineActivityMaps");
            builder.HasKey(k => k.Id);

            builder
                .HasOne(p => p.Discipline)
                .WithMany(p => p.DisciplineActivityMaps)
                .HasForeignKey(fk => fk.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.Activity)
                .WithMany(p => p.DisciplineActivityMaps)
                .HasForeignKey(fk => fk.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
