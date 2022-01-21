using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Persistence.Configurations
{
    class EmployeeBossHistoryConfiguration : IEntityTypeConfiguration<EmployeeBossHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeeBossHistory> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            // FromDate is required
            builder.Property(b => b.FromDate)
            .IsRequired();

            // OfficeId BossUserId is Unique
            builder
               .HasIndex(b => new { b.FromDate, b.ApplicationUserId, b.BossUserId })
               .IsUnique();

            builder.HasOne(e => e.ApplicationUser).WithMany().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
