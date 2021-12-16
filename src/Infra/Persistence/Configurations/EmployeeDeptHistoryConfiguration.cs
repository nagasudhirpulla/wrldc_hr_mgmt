using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Infra.Persistence.Configurations
{
    public class EmployeeDeptHistoryConfiguration : IEntityTypeConfiguration<EmployeeDeptHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeeDeptHistory> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            // FromDate is required
            builder.Property(b => b.FromDate)
            .IsRequired();

            // OfficeId DepartmentId is Unique
            builder
               .HasIndex(b => new { b.FromDate, b.ApplicationUserId, b.DepartmentId })
               .IsUnique();

        }
    }
}