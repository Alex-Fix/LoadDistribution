using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoadDistribution.Data.Configurations
{
    public class LecturerDisciplineActivityMapConfiguration : IEntityTypeConfiguration<LecturerDisciplineActivityMap>
    {
        public void Configure(EntityTypeBuilder<LecturerDisciplineActivityMap> builder)
        {
            builder.ToTable("LecturerDisciplineActivityMaps");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Created).HasConversion(new DateTimeOffsetToBinaryConverter());
            builder.Property(p => p.Updated).HasConversion(new DateTimeOffsetToBinaryConverter());

            builder.HasIndex(p => new { p.ProjectId, p.LecturerId, p.DisciplineActivityMapId }).IsUnique();

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p.LecturerDisciplineActivityMaps)
                .HasForeignKey(fk => fk.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
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
