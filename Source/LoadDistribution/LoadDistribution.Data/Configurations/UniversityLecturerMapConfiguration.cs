using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoadDistribution.Data.Configurations
{
    public class UniversityLecturerMapConfiguration : IEntityTypeConfiguration<UniversityLecturerMap>
    {
        public void Configure(EntityTypeBuilder<UniversityLecturerMap> builder)
        {
            builder.ToTable("UniversityLecturerMaps");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Created).HasConversion(new DateTimeOffsetToBinaryConverter());
            builder.Property(p => p.Updated).HasConversion(new DateTimeOffsetToBinaryConverter());

            builder.HasIndex(p => new { p.ProjectId, p.UniversityId, p.LectureId }).IsUnique();

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
