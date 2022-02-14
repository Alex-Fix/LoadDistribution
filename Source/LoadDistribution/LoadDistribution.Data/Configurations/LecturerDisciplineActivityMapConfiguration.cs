using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoadDistribution.Data.Configurations
{
    public class LecturerDisciplineActivityMapConfiguration : IEntityTypeConfiguration<LecturerDisciplineActivityMap>
    {
        public void Configure(EntityTypeBuilder<LecturerDisciplineActivityMap> builder)
        {
            builder.ToTable("LecturerDisciplineActivityMaps");
            builder.HasKey(k => k.Id);

            builder
                .HasOne(p => p.Lecturer)
                .WithMany(p => p.LecturerDisciplineActivityMaps)
                .HasForeignKey(fk => fk.LecturerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.DisciplineActivityMap)
                .WithMany(p => p.LecturerDisciplineActivityMaps)
                .HasForeignKey(fk => fk.DisciplineActivityMapId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
