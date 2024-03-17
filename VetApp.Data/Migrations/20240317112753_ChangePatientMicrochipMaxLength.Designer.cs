﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetApp.Data;

#nullable disable

namespace VetApp.Data.Migrations
{
    [DbContext(typeof(VetAppDbContext))]
    [Migration("20240317112753_ChangePatientMicrochipMaxLength")]
    partial class ChangePatientMicrochipMaxLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VetApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                            AccessFailedCount = 0,
                            Address = "123 Main St Haskovo",
                            ConcurrencyStamp = "15d11bd2-72a7-47b4-ac38-16bf8de37246",
                            Email = "r_raykov@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Radoslav",
                            LastName = "Raykov",
                            LockoutEnabled = true,
                            NormalizedEmail = "R_RAYKOV@GMAIL.COM",
                            NormalizedUserName = "R_RAYKOV",
                            PasswordHash = "AQAAAAEAACcQAAAAEBAp1rc37M0Pdpw6Mim9j47dZuy+2sWak/CvXviltg82H1iRRQm3Sc3NwbA+RHLiSg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "A38945F5-0E87-4231-9C47-5B66C91525C0",
                            TwoFactorEnabled = false,
                            UserName = "r_raykov"
                        });
                });

            modelBuilder.Entity("VetApp.Data.Models.Examination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentCondition")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Diagnosis")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Exit")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MedicalHistory")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Research")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SpecificCondition")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Surgery")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Therapy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("StatusId");

                    b.ToTable("Examinations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
                            CreatedOn = new DateTime(2024, 3, 17, 11, 27, 52, 879, DateTimeKind.Utc).AddTicks(9503),
                            DoctorId = new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                            PatientId = new Guid("b19105c4-9a4e-4583-973a-642b8bc06916"),
                            Reason = "Primary",
                            StatusId = 1,
                            Weight = 12.0
                        },
                        new
                        {
                            Id = new Guid("917f60f0-485a-4cbc-a3d5-83bfc30015ed"),
                            CreatedOn = new DateTime(2024, 3, 17, 11, 27, 52, 879, DateTimeKind.Utc).AddTicks(9515),
                            DoctorId = new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                            PatientId = new Guid("ad53d8a9-6ac2-4ab1-bf68-dfb4292e56ab"),
                            Reason = "Secondary",
                            StatusId = 3,
                            Weight = 10.0
                        },
                        new
                        {
                            Id = new Guid("c84db966-6f32-44af-8026-d142b1ea15b9"),
                            CreatedOn = new DateTime(2024, 3, 17, 11, 27, 52, 879, DateTimeKind.Utc).AddTicks(9526),
                            DoctorId = new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                            PatientId = new Guid("53044ff9-b935-4b5a-a7e0-2203e21b05ea"),
                            Reason = "Primary",
                            StatusId = 3,
                            Weight = 30.0
                        },
                        new
                        {
                            Id = new Guid("b05fb0d0-9e05-4c00-a9e7-d3f0600e566b"),
                            CreatedOn = new DateTime(2024, 3, 17, 11, 27, 52, 879, DateTimeKind.Utc).AddTicks(9530),
                            DoctorId = new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                            PatientId = new Guid("a917fe0d-e64e-40c5-8eeb-b17867ec09e1"),
                            Reason = "Primary",
                            StatusId = 4,
                            Weight = 25.0
                        });
                });

            modelBuilder.Entity("VetApp.Data.Models.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
                            Address = "ул. Света Параскева 10, София 1000",
                            IsActive = false,
                            Name = "Ivan",
                            PhoneNumber = "+359876123123"
                        },
                        new
                        {
                            Id = new Guid("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
                            Address = "бул. Цариградско шосе 24, Пловдив 4000",
                            IsActive = false,
                            Name = "Milko",
                            PhoneNumber = "+359878255255"
                        },
                        new
                        {
                            Id = new Guid("6625a7bb-93ea-4bad-b228-a408be9725e9"),
                            Address = "жк. Лозенец, ул. Розова долина 7, Варна 9000",
                            IsActive = false,
                            Name = "Dimo",
                            PhoneNumber = "+359988989898"
                        },
                        new
                        {
                            Id = new Guid("2e8fb8ae-6d2e-46a9-af4a-0b14ab081476"),
                            Address = "ул. Дунав 15, Велико Търново 5000",
                            IsActive = false,
                            Name = "Mihaela",
                            PhoneNumber = "+359878358235"
                        });
                });

            modelBuilder.Entity("VetApp.Data.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Characteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChronicIllnesses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Microchip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Neutered")
                        .HasColumnType("int");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b19105c4-9a4e-4583-973a-642b8bc06916"),
                            Gender = 0,
                            IsActive = false,
                            Name = "Frank",
                            Neutered = 0,
                            OwnerId = new Guid("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
                            Type = "Dog"
                        },
                        new
                        {
                            Id = new Guid("ad53d8a9-6ac2-4ab1-bf68-dfb4292e56ab"),
                            Gender = 0,
                            IsActive = false,
                            Name = "Tom",
                            Neutered = 2,
                            OwnerId = new Guid("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
                            Type = "Cat"
                        },
                        new
                        {
                            Id = new Guid("53044ff9-b935-4b5a-a7e0-2203e21b05ea"),
                            Gender = 1,
                            IsActive = false,
                            Name = "Jerry",
                            Neutered = 1,
                            OwnerId = new Guid("6625a7bb-93ea-4bad-b228-a408be9725e9"),
                            Type = "Mouse"
                        },
                        new
                        {
                            Id = new Guid("a917fe0d-e64e-40c5-8eeb-b17867ec09e1"),
                            Gender = 1,
                            IsActive = false,
                            Name = "Bella",
                            Neutered = 0,
                            OwnerId = new Guid("2e8fb8ae-6d2e-46a9-af4a-0b14ab081476"),
                            Type = "Dog"
                        });
                });

            modelBuilder.Entity("VetApp.Data.Models.PatientUser", b =>
                {
                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientsUsers");

                    b.HasComment("User Patints");
                });

            modelBuilder.Entity("VetApp.Data.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Done"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hospital"
                        },
                        new
                        {
                            Id = 4,
                            Name = "New"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("VetApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("VetApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("VetApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VetApp.Data.Models.Examination", b =>
                {
                    b.HasOne("VetApp.Data.Models.ApplicationUser", "Doctor")
                        .WithMany("Examinations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetApp.Data.Models.Patient", "Patient")
                        .WithMany("Examinations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetApp.Data.Models.Status", "Status")
                        .WithMany("Examinations")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("VetApp.Data.Models.Patient", b =>
                {
                    b.HasOne("VetApp.Data.Models.Owner", "Owner")
                        .WithMany("Patients")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("VetApp.Data.Models.PatientUser", b =>
                {
                    b.HasOne("VetApp.Data.Models.ApplicationUser", "Doctor")
                        .WithMany("PatientsUsers")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetApp.Data.Models.Patient", "Patient")
                        .WithMany("PatientsUsers")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("VetApp.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Examinations");

                    b.Navigation("PatientsUsers");
                });

            modelBuilder.Entity("VetApp.Data.Models.Owner", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("VetApp.Data.Models.Patient", b =>
                {
                    b.Navigation("Examinations");

                    b.Navigation("PatientsUsers");
                });

            modelBuilder.Entity("VetApp.Data.Models.Status", b =>
                {
                    b.Navigation("Examinations");
                });
#pragma warning restore 612, 618
        }
    }
}
