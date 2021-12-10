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
            // Name is required and just 250 characters
            builder.Property(b => b.DeptName)
                .IsRequired()
                .HasMaxLength(50);

            // FromDate is required
            builder.Property(b => b.FromDate)
            .IsRequired();

            // FromDate OfficeId DepartmentId is Unique
            builder
               .HasIndex(b => new { b.FromDate, b.OfficeId, b.DepartmentId })
               .IsUnique();

        }
    }
}