using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadDistribution.Data.Configurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<University> builder)
        {
            builder.ToTable("Universities");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p.Universities)
                .HasForeignKey(fk => fk.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
