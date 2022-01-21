using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infra.Persistence.Configurations
{
    class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(b => b.UserName)
               .IsRequired();


            builder.Property(b => b.OfficeId)
                .HasMaxLength(10);

            builder
            .HasIndex(b => b.OfficeId)
            .IsUnique();
        }
    }
}