﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infra.Persistence.Configurations
{
    public class DesignationConfiguration : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            // Name is required and just 250 characters
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(b => b.Grade)
                .IsRequired()
                .HasMaxLength(250);

            // Name is unique
            builder
            .HasIndex(b => b.Name)
            .IsUnique();

            // grade is unique
            builder
            .HasIndex(b => b.Grade)
            .IsUnique();

        }
    }
}