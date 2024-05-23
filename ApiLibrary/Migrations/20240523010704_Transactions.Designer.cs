﻿// <auto-generated />
using System;
using ApiLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240523010704_Transactions")]
    partial class Transactions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiLibrary.Models.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benefits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food and drinks"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Recreation"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Culture"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Travelling"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Shopping"
                        });
                });

            modelBuilder.Entity("ApiLibrary.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 10000m,
                            CardNumber = "1234123412341234",
                            EmployeeId = 1,
                            Pin = "$2a$11$94PsOmiM9HZCslYFpYsfjugoSSoRK4ctEsVeEplUC4ojxvaoIhkIy"
                        },
                        new
                        {
                            Id = 2,
                            Balance = 20000m,
                            CardNumber = "2345234523452345",
                            EmployeeId = 2,
                            Pin = "$2a$11$XTP6VlNJLmnpSTTOaPWwge5LFkMPrx4I2tFvFstB682CMB8deegvK"
                        },
                        new
                        {
                            Id = 3,
                            Balance = 30000m,
                            CardNumber = "3456345634563456",
                            EmployeeId = 3,
                            Pin = "$2a$11$A6uR/3hQ372uQBcgiWl1POASMCwRRV7Af4Uwq9zbb0O/9THM0eRB."
                        },
                        new
                        {
                            Id = 4,
                            Balance = 40000m,
                            CardNumber = "4567456745674567",
                            EmployeeId = 4,
                            Pin = "$2a$11$qbFNaq1S.d8T2rPzceUoQepHdVzh3dsnhLrNvKwSu.ad8OHN5BdXK"
                        },
                        new
                        {
                            Id = 5,
                            Balance = 50000m,
                            CardNumber = "5678567856785678",
                            EmployeeId = 5,
                            Pin = "$2a$11$NX1GCbFw2LTpTIsTxwmXHuZiKSM/PjcYwZBhuWqgu9J/4lCr3qQT2"
                        },
                        new
                        {
                            Id = 6,
                            Balance = 60000m,
                            CardNumber = "6789678967896789",
                            EmployeeId = 6,
                            Pin = "$2a$11$/sMHybFoljfrKl44W9s9qOlgQ3FNuH2v/9NI51E07PCLjEbEjSTOm"
                        },
                        new
                        {
                            Id = 7,
                            Balance = 70000m,
                            CardNumber = "7890789078907890",
                            EmployeeId = 7,
                            Pin = "$2a$11$Jdo0yUzSTJrRAUX0P2fkJuKLayq7rIqG/4IY5boZfjXiIdogh2v0G"
                        },
                        new
                        {
                            Id = 8,
                            Balance = 80000m,
                            CardNumber = "8901890189018901",
                            EmployeeId = 8,
                            Pin = "$2a$11$TYTTUZ.V8IAxUqqDu4leY.wsJvettnNgTPqYsgujMSrxCxS8Tduti"
                        },
                        new
                        {
                            Id = 9,
                            Balance = 90000m,
                            CardNumber = "9012901290129012",
                            EmployeeId = 9,
                            Pin = "$2a$11$EdWxaMPMQGnYrc9QY88jyuFrROuOdt8eh.s4sqdNhTK7icbSPtBYO"
                        });
                });

            modelBuilder.Entity("ApiLibrary.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Standard Users"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Premium Users"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Platinum Users"
                        });
                });

            modelBuilder.Entity("ApiLibrary.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 2, 182, DateTimeKind.Local).AddTicks(334),
                            Email = "admin@benefitseller.com",
                            IsDeleted = false,
                            Name = "BenefitSeller",
                            Password = "$2a$11$EX.XQDbKA4pCOpdfDNhTRO2l8AJvhrIF3d1n/CyIu2rayq2WzypGW",
                            RefreshToken = "",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 2, 293, DateTimeKind.Local).AddTicks(9997),
                            Email = "info@techcorp.com",
                            IsDeleted = false,
                            Name = "TechCorp",
                            Password = "$2a$11$ChznQ2xR.XuqPTcLeVwQduYYM4jXM5h7HwmJ4flKa6n1EjHrjn2u6",
                            RefreshToken = "",
                            Role = "Company"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 2, 406, DateTimeKind.Local).AddTicks(4157),
                            Email = "contact@globalsolutions.com",
                            IsDeleted = false,
                            Name = "GlobalSolutions",
                            Password = "$2a$11$3VzlnUR7b6EOcnUqaO4O3.YtKw/8rGMdaRji24fw364zmaPRUDtPK",
                            RefreshToken = "",
                            Role = "Company"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 2, 517, DateTimeKind.Local).AddTicks(2452),
                            Email = "hello@innovatetech.com",
                            IsDeleted = false,
                            Name = "InnovateTech",
                            Password = "$2a$11$iiccAu2XJzISQ3uL6rf5OeNyswLjE/M.sfQ43VbEOMBZGCnTdd2/W",
                            RefreshToken = "",
                            Role = "Company"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 2, 627, DateTimeKind.Local).AddTicks(4404),
                            Email = "info@swiftenterprises.com",
                            IsDeleted = false,
                            Name = "SwiftEnterprises",
                            Password = "$2a$11$5ye1zu8l2n.WNgFc0atq7OIY.ZvSQooHAvxJP3YMHl4g/hMkcBbxq",
                            RefreshToken = "",
                            Role = "Company"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 2, 737, DateTimeKind.Local).AddTicks(7129),
                            Email = "contact@alphainnovations.com",
                            IsDeleted = false,
                            Name = "AlphaInnovations",
                            Password = "$2a$11$0bhc9MEg3xg4rwr1aF2Vjud5a3Ce0X8V3bTOCJtNUtuF2UbQ/l3lS",
                            RefreshToken = "",
                            Role = "Company"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 2, 848, DateTimeKind.Local).AddTicks(988),
                            Email = "info@globalnetworks.com",
                            IsDeleted = false,
                            Name = "GlobalNetworks",
                            Password = "$2a$11$ix6RH1kZ/OHOpCXE6gGKC.Qef8yjjU6RD2XDPwHPUYyJFUvYoqBoK",
                            RefreshToken = "",
                            Role = "Company"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 2, 958, DateTimeKind.Local).AddTicks(2608),
                            Email = "hello@techsavvy.com",
                            IsDeleted = false,
                            Name = "TechSavvy",
                            Password = "$2a$11$UC6KULpKWXdycKn.Jve2dezHSvKFIBGXkSMNtC2kma/f6NJnNMLq2",
                            RefreshToken = "",
                            Role = "Company"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 3, 68, DateTimeKind.Local).AddTicks(6919),
                            Email = "info@innovatehub.com",
                            IsDeleted = false,
                            Name = "InnovateHub",
                            Password = "$2a$11$y5NVR7Ab1i/InALlohVcBewukVwyrNV8aoV3o7VLw2zd.fWGtVQOW",
                            RefreshToken = "",
                            Role = "Company"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 5, 23, 3, 7, 3, 179, DateTimeKind.Local).AddTicks(1444),
                            Email = "contact@alphatech.com",
                            IsDeleted = false,
                            Name = "AlphaTech",
                            Password = "$2a$11$kdjR2AKT92234kP04OTfJOdvsIxc094ue6bTE.EuaIdDVaBqWUN9u",
                            RefreshToken = "",
                            Role = "Company"
                        });
                });

            modelBuilder.Entity("ApiLibrary.Models.CompanyBenefits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BenefitId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BenefitId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyBenefits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BenefitId = 1,
                            CompanyId = 2
                        },
                        new
                        {
                            Id = 2,
                            BenefitId = 3,
                            CompanyId = 2
                        },
                        new
                        {
                            Id = 3,
                            BenefitId = 5,
                            CompanyId = 2
                        },
                        new
                        {
                            Id = 4,
                            BenefitId = 4,
                            CompanyId = 3
                        },
                        new
                        {
                            Id = 5,
                            BenefitId = 3,
                            CompanyId = 3
                        },
                        new
                        {
                            Id = 6,
                            BenefitId = 1,
                            CompanyId = 4
                        },
                        new
                        {
                            Id = 7,
                            BenefitId = 5,
                            CompanyId = 4
                        },
                        new
                        {
                            Id = 8,
                            BenefitId = 6,
                            CompanyId = 4
                        },
                        new
                        {
                            Id = 9,
                            BenefitId = 2,
                            CompanyId = 5
                        },
                        new
                        {
                            Id = 10,
                            BenefitId = 6,
                            CompanyId = 5
                        },
                        new
                        {
                            Id = 11,
                            BenefitId = 4,
                            CompanyId = 6
                        },
                        new
                        {
                            Id = 12,
                            BenefitId = 3,
                            CompanyId = 6
                        },
                        new
                        {
                            Id = 13,
                            BenefitId = 2,
                            CompanyId = 7
                        },
                        new
                        {
                            Id = 14,
                            BenefitId = 1,
                            CompanyId = 7
                        },
                        new
                        {
                            Id = 15,
                            BenefitId = 1,
                            CompanyId = 8
                        },
                        new
                        {
                            Id = 16,
                            BenefitId = 4,
                            CompanyId = 8
                        },
                        new
                        {
                            Id = 17,
                            BenefitId = 3,
                            CompanyId = 9
                        },
                        new
                        {
                            Id = 18,
                            BenefitId = 2,
                            CompanyId = 9
                        },
                        new
                        {
                            Id = 19,
                            BenefitId = 1,
                            CompanyId = 9
                        },
                        new
                        {
                            Id = 20,
                            BenefitId = 3,
                            CompanyId = 10
                        },
                        new
                        {
                            Id = 21,
                            BenefitId = 2,
                            CompanyId = 10
                        });
                });

            modelBuilder.Entity("ApiLibrary.Models.CompanyMerchantsDiscounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MerchantId");

                    b.ToTable("CompanyMerchantsDiscounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 2,
                            Discount = 10m,
                            MerchantId = 1
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 2,
                            Discount = 15m,
                            MerchantId = 10
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 3,
                            Discount = 20m,
                            MerchantId = 5
                        },
                        new
                        {
                            Id = 4,
                            CompanyId = 4,
                            Discount = 25m,
                            MerchantId = 10
                        },
                        new
                        {
                            Id = 5,
                            CompanyId = 5,
                            Discount = 30m,
                            MerchantId = 13
                        },
                        new
                        {
                            Id = 6,
                            CompanyId = 6,
                            Discount = 35m,
                            MerchantId = 6
                        },
                        new
                        {
                            Id = 7,
                            CompanyId = 7,
                            Discount = 40m,
                            MerchantId = 4
                        });
                });

            modelBuilder.Entity("ApiLibrary.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CompanyId = 2,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CompanyId = 2,
                            Name = "Jane Doe"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CompanyId = 3,
                            Name = "Alice"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CompanyId = 3,
                            Name = "Bob"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            CompanyId = 3,
                            Name = "Charlie"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            CompanyId = 4,
                            Name = "David"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            CompanyId = 5,
                            Name = "Eve"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            CompanyId = 5,
                            Name = "Frank"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            CompanyId = 6,
                            Name = "Grace"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            CompanyId = 6,
                            Name = "Henry"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            CompanyId = 7,
                            Name = "Ivy"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            CompanyId = 7,
                            Name = "Jack"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 2,
                            CompanyId = 8,
                            Name = "Kate"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            CompanyId = 8,
                            Name = "Liam"
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 1,
                            CompanyId = 9,
                            Name = "Mia"
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            CompanyId = 9,
                            Name = "Noah"
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 3,
                            CompanyId = 10,
                            Name = "Olivia"
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 1,
                            CompanyId = 10,
                            Name = "Peter"
                        });
                });

            modelBuilder.Entity("ApiLibrary.Models.Merchant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BenefitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BenefitId");

                    b.ToTable("Merchants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BenefitId = 1,
                            Name = "Fast Food"
                        },
                        new
                        {
                            Id = 2,
                            BenefitId = 1,
                            Name = "Restoraunt"
                        },
                        new
                        {
                            Id = 3,
                            BenefitId = 2,
                            Name = "Gym"
                        },
                        new
                        {
                            Id = 4,
                            BenefitId = 2,
                            Name = "Boxing"
                        },
                        new
                        {
                            Id = 5,
                            BenefitId = 3,
                            Name = "School"
                        },
                        new
                        {
                            Id = 6,
                            BenefitId = 3,
                            Name = "University"
                        },
                        new
                        {
                            Id = 7,
                            BenefitId = 3,
                            Name = "Englis Course"
                        },
                        new
                        {
                            Id = 8,
                            BenefitId = 4,
                            Name = "Museum"
                        },
                        new
                        {
                            Id = 9,
                            BenefitId = 4,
                            Name = "Theater"
                        },
                        new
                        {
                            Id = 10,
                            BenefitId = 5,
                            Name = "Travel Agency"
                        },
                        new
                        {
                            Id = 11,
                            BenefitId = 6,
                            Name = "Shoe store"
                        },
                        new
                        {
                            Id = 12,
                            BenefitId = 6,
                            Name = "Clothing store"
                        },
                        new
                        {
                            Id = 13,
                            BenefitId = 6,
                            Name = "Bookstore"
                        });
                });

            modelBuilder.Entity("ApiLibrary.Models.Transactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MerchantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ApiLibrary.Models.Card", b =>
                {
                    b.HasOne("ApiLibrary.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ApiLibrary.Models.CompanyBenefits", b =>
                {
                    b.HasOne("ApiLibrary.Models.Benefit", "Benefit")
                        .WithMany()
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiLibrary.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ApiLibrary.Models.CompanyMerchantsDiscounts", b =>
                {
                    b.HasOne("ApiLibrary.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiLibrary.Models.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("ApiLibrary.Models.Employee", b =>
                {
                    b.HasOne("ApiLibrary.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiLibrary.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ApiLibrary.Models.Merchant", b =>
                {
                    b.HasOne("ApiLibrary.Models.Benefit", "Benefit")
                        .WithMany()
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");
                });
#pragma warning restore 612, 618
        }
    }
}