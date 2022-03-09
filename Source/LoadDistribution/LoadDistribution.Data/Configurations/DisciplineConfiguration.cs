using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoadDistribution.Data.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable("Disciplines");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Type).HasMaxLength(64);
            builder.Property(p => p.EducationForm).IsRequired().HasMaxLength(64);
            builder.Property(p => p.PlanIndex).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Speciality).IsRequired().HasMaxLength(64);
            builder.Property(p => p.GroupAbbreviation).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Specialization).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Created).HasConversion(new DateTimeOffsetToBinaryConverter());
            builder.Property(p => p.Updated).HasConversion(new DateTimeOffsetToBinaryConverter());

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p.Disciplines)
                .HasForeignKey(fk => fk.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.University)
                .WithMany(p => p.Disciplines)
                .HasForeignKey(p => p.UniversityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
