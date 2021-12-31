using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infra.Persistence.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            // Name is required and just 250 characters
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(250);

            // Name is unique
            builder
            .HasIndex(b => b.Name)
            .IsUnique();

            // configure payscale value object
            builder
            .OwnsOne(b => b.PayScale);
        }
    }
}