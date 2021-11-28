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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Name is required and just 250 characters
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(250);

            // Name is unique
            builder
            .HasIndex(b => b.Name)
            .IsUnique();

        }
    }
}