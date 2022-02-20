using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoadDistribution.Data.Configurations
{
    public class UniversityLecturerMapConfiguration : IEntityTypeConfiguration<UniversityLecturerMap>
    {
        public void Configure(EntityTypeBuilder<UniversityLecturerMap> builder)
        {
            builder.ToTable("UniversityLecturerMaps");
            builder.HasKey(k => k.Id);

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p.UniversityLecturerMaps)
                .HasForeignKey(fk => fk.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.University)
                .WithMany(p => p.UniversityLectureMaps)
                .HasForeignKey(fk => fk.UniversityId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.Lecturer)
                .WithMany(p => p.UniversityLectureMaps)
                .HasForeignKey(fk => fk.LectureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
