﻿// <auto-generated />
using System;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Core.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Aadhar")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("BossUserId")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateofJoining")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int?>("DesignationId")
                        .HasColumnType("integer");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DomicileState")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int?>("EthnicOrigin")
                        .HasColumnType("integer");

                    b.Property<string>("FatherName")
                        .HasColumnType("text");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<int?>("GradeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("OfficeId")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("PAN")
                        .HasColumnType("text");

                    b.Property<string>("PRAN")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Religion")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int?>("SpeciallyAbled")
                        .HasColumnType("integer");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UAN")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("BossUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("GradeId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("OfficeId")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Core.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Core.Entities.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("Core.Entities.EmployeeBossHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("BossUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BossUserId");

                    b.HasIndex("FromDate", "ApplicationUserId", "BossUserId")
                        .IsUnique();

                    b.ToTable("EmployeeBossHistorys");
                });

            modelBuilder.Entity("Core.Entities.EmployeeDeptHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FromDate", "ApplicationUserId", "DepartmentId")
                        .IsUnique();

                    b.ToTable("EmployeeDeptHistorys");
                });

            modelBuilder.Entity("Core.Entities.EmployeeDesignationHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<int>("DesignationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("FromDate", "ApplicationUserId", "DesignationId")
                        .IsUnique();

                    b.ToTable("EmployeeDesignationHistorys");
                });

            modelBuilder.Entity("Core.Entities.EmployeeGradeHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("GradeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("GradeId");

                    b.HasIndex("FromDate", "ApplicationUserId", "GradeId")
                        .IsUnique();

                    b.ToTable("EmployeeGradeHistorys");
                });

            modelBuilder.Entity("Core.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Core.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", "BossUser")
                        .WithMany()
                        .HasForeignKey("BossUserId");

                    b.HasOne("Core.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Core.Entities.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId");

                    b.HasOne("Core.Entities.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId");

                    b.Navigation("BossUser");

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("Core.Entities.EmployeeBossHistory", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Entities.ApplicationUser", "BossUser")
                        .WithMany()
                        .HasForeignKey("BossUserId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("BossUser");
                });

            modelBuilder.Entity("Core.Entities.EmployeeDeptHistory", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Core.Entities.EmployeeDesignationHistory", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Entities.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Designation");
                });

            modelBuilder.Entity("Core.Entities.EmployeeGradeHistory", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Entities.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("Core.Entities.Grade", b =>
                {
                    b.OwnsOne("Core.ValueObjects.PayScale", "PayScale", b1 =>
                        {
                            b1.Property<int>("GradeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("HighVal")
                                .HasColumnType("integer");

                            b1.Property<int>("LowVal")
                                .HasColumnType("integer");

                            b1.HasKey("GradeId");

                            b1.ToTable("Grades");

                            b1.WithOwner()
                                .HasForeignKey("GradeId");
                        });

                    b.Navigation("PayScale");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
