using ApiLibrary.Helpers;
using ApiLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<CompanyBenefits> CompanyBenefits { get; set;  }
        public DbSet<CompanyMerchantsDiscounts> CompanyMerchantsDiscounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Company>().HasData(
                new Company
                               {
                                   Id = 1,
                                   Name = "BenefitSeller",
                                   Email = "admin@benefitseller.com",
                                   Password = BCrypt.Net.BCrypt.HashPassword("BenefitSeller"),
                                   Role = Constants.AdminRole,
                                   CreatedAt = DateTime.Now,
                               },
                new Company
                                {
                                    Id = 2,
                                    Name = "TechCorp",
                                    Email = "info@techcorp.com",
                                    Password = BCrypt.Net.BCrypt.HashPassword("TechCorp"),
                                    Role = Constants.CompanyRole,
                                    CreatedAt = DateTime.Now,
                                },
                new Company
        {
            Id = 3,
            Name = "GlobalSolutions",
            Email = "contact@globalsolutions.com",
            Password = BCrypt.Net.BCrypt.HashPassword("GlobalSolutions"),
            Role = Constants.CompanyRole,
            CreatedAt = DateTime.Now,
        },
                new Company
        {
            Id = 4,
            Name = "InnovateTech",
            Email = "hello@innovatetech.com",
            Password = BCrypt.Net.BCrypt.HashPassword("InnovateTech"),
            Role = Constants.CompanyRole,
            CreatedAt = DateTime.Now,
        },
                new Company
        {
            Id = 5,
            Name = "SwiftEnterprises",
            Email = "info@swiftenterprises.com",
            Password = BCrypt.Net.BCrypt.HashPassword("SwiftEnterprises"),
            Role = Constants.CompanyRole,
            CreatedAt = DateTime.Now,
        },
                new Company
        {
            Id = 6,
            Name = "AlphaInnovations",
            Email = "contact@alphainnovations.com",
            Password = BCrypt.Net.BCrypt.HashPassword("AlphaInnovations"),
            Role = Constants.CompanyRole,
            CreatedAt = DateTime.Now,
        },
                new Company
        {
            Id = 7,
            Name = "GlobalNetworks",
            Email = "info@globalnetworks.com",
            Password = BCrypt.Net.BCrypt.HashPassword("GlobalNetworks"),
            Role = Constants.CompanyRole,
            CreatedAt = DateTime.Now,
        },
                new Company
        {
            Id = 8,
            Name = "TechSavvy",
            Email = "hello@techsavvy.com",
            Password = BCrypt.Net.BCrypt.HashPassword("TechSavvy"),
            Role = Constants.CompanyRole,
            CreatedAt = DateTime.Now,
        },
                new Company
        {
            Id = 9,
            Name = "InnovateHub",
            Email = "info@innovatehub.com",
            Password = BCrypt.Net.BCrypt.HashPassword("InnovateHub"),
            Role = Constants.CompanyRole,
            CreatedAt = DateTime.Now,
        },
                new Company
        {
            Id = 10,
            Name = "AlphaTech",
            Email = "contact@alphatech.com",
            Password = BCrypt.Net.BCrypt.HashPassword("AlphaTech"),
            Role = Constants.CompanyRole,
            CreatedAt = DateTime.Now,
        });

            modelBuilder.Entity<Benefit>().HasData(
                new Benefit
                {
                    Id = 1,
                    Name = "Food and drinks"
                },
                new Benefit
                {
                    Id = 2,
                    Name = "Recreation"
                },
                new Benefit
                {
                    Id = 3,
                    Name = "Education"
                },
                new Benefit
                {
                    Id = 4,
                    Name = "Culture"
                },
                new Benefit
                {
                    Id = 5,
                    Name = "Travelling"
                },
                new Benefit
                {
                    Id = 6,
                    Name = "Shopping"
                });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Standard Users"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Premium Users"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Platinum Users"
                });

            modelBuilder.Entity<Merchant>().HasData(

               new Merchant
               {
                   Id = 1,
                   Name = "Fast Food",
                   BenefitId = 1,
               },
               new Merchant
               {
                   Id = 2,
                   Name = "Restoraunt",
                   BenefitId = 1,
               },
               new Merchant
               {
                   Id = 3,
                   Name = "Gym",
                   BenefitId = 2,
               },
               new Merchant
               {
                   Id = 4,
                   Name = "Boxing",
                   BenefitId = 2,
               },
               new Merchant
               {
                   Id = 5,
                   Name = "School",
                   BenefitId = 3,
               },
               new Merchant
               {
                   Id = 6,
                   Name = "University",
                   BenefitId = 3,
               },
               new Merchant
               {
                   Id = 7,
                   Name = "Englis Course",
                   BenefitId = 3,
               },
               new Merchant
               {
                   Id = 8,
                   Name = "Museum",
                   BenefitId = 4,
               },
               new Merchant
               {
                   Id = 9,
                   Name = "Theater",
                   BenefitId = 4,
               },
               new Merchant
               {
                   Id = 10,
                   Name = "Travel Agency",
                   BenefitId = 5,
               },
               new Merchant
               {
                   Id = 11,
                   Name = "Shoe store",
                   BenefitId = 6,
               },
               new Merchant
               {
                   Id = 12,
                   Name = "Clothing store",
                   BenefitId = 6,
               },
               new Merchant
               {
                   Id = 13,
                   Name = "Bookstore",
                   BenefitId = 6,
               }
               );

            modelBuilder.Entity<CompanyBenefits>().HasData(
                new CompanyBenefits
                {
                    Id = 1,
                    CompanyId = 2,
                    BenefitId = 1
                },
                new CompanyBenefits
                {
                    Id = 2,
                    CompanyId = 2,
                    BenefitId = 3
                },
                new CompanyBenefits
                {
                    Id = 3,
                    CompanyId = 2,
                    BenefitId = 5
                },
                new CompanyBenefits
                {
                    Id = 4,
                    CompanyId = 3,
                    BenefitId = 4
                },
                new CompanyBenefits
                {
                    Id = 5,
                    CompanyId = 3,
                    BenefitId = 3
                },
                new CompanyBenefits
                {
                    Id = 6,
                    CompanyId = 4,
                    BenefitId = 1
                },
                new CompanyBenefits
                {
                    Id = 7,
                    CompanyId = 4,
                    BenefitId = 5
                },
                new CompanyBenefits
                {
                    Id = 8,
                    CompanyId = 4,
                    BenefitId = 6
                },
                new CompanyBenefits
                {
                    Id = 9,
                    CompanyId = 5,
                    BenefitId = 2
                },
                new CompanyBenefits
                {
                    Id = 10,
                    CompanyId = 5,
                    BenefitId = 6
                },
                new CompanyBenefits
                {
                    Id = 11,
                    CompanyId = 6,
                    BenefitId = 4
                },
                new CompanyBenefits
                {
                    Id = 12,
                    CompanyId = 6,
                    BenefitId = 3
                },
                new CompanyBenefits
                 {
                     Id = 13,
                     CompanyId = 7,
                     BenefitId = 2
                 },
                new CompanyBenefits
                  {
                      Id = 14,
                      CompanyId = 7,
                      BenefitId = 1
                  },
                new CompanyBenefits
                   {
                       Id = 15,
                       CompanyId = 8,
                       BenefitId = 1
                   },
                new CompanyBenefits
                    {
                        Id = 16,
                        CompanyId = 8,
                        BenefitId = 4
                    },
                new CompanyBenefits
                     {
                         Id = 17,
                         CompanyId = 9,
                         BenefitId = 3
                     },
                new CompanyBenefits
                      {
                          Id = 18,
                          CompanyId = 9,
                          BenefitId = 2
                      },
                new CompanyBenefits
                       {
                           Id = 19,
                           CompanyId = 9,
                           BenefitId = 1
                       },
                new CompanyBenefits
                        {
                            Id = 20,
                            CompanyId = 10,
                            BenefitId = 3
                        },
                new CompanyBenefits
                         {
                             Id = 21,
                             CompanyId = 10,
                             BenefitId = 2
                         }
                );

            modelBuilder.Entity<CompanyMerchantsDiscounts>().HasData(
                new CompanyMerchantsDiscounts
                {
                    Id = 1,
                    CompanyId = 2,
                    MerchantId = 1,
                    Discount = 10
                },
                new CompanyMerchantsDiscounts
                {
                    Id = 2,
                    CompanyId = 2,
                    MerchantId = 10,
                    Discount = 15
                },
                new CompanyMerchantsDiscounts
                {
                    Id = 3,
                    CompanyId = 3,
                    MerchantId = 5,
                    Discount = 20
                },
                new CompanyMerchantsDiscounts
                {
                    Id = 4,
                    CompanyId = 4,
                    MerchantId = 10,
                    Discount = 25
                },
                new CompanyMerchantsDiscounts
                {
                    Id = 5,
                    CompanyId = 5,
                    MerchantId = 13,
                    Discount = 30
                },
                new CompanyMerchantsDiscounts
                {
                    Id = 6,
                    CompanyId = 6,
                    MerchantId = 6,
                    Discount = 35
                },
                new CompanyMerchantsDiscounts
                {
                    Id = 7,
                    CompanyId = 7,
                    MerchantId = 4,
                    Discount = 40
                }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "John Doe",
                    CompanyId = 2,
                    CategoryId = 1,
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Jane Doe",
                    CompanyId = 2,
                    CategoryId = 2,
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Alice",
                    CompanyId = 3,
                    CategoryId = 3,
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Bob",
                    CompanyId = 3,
                    CategoryId = 2,
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Charlie",
                    CompanyId = 3,
                    CategoryId = 3
                },
                new Employee()
                {
                    Id = 6,
                    Name = "David",
                    CompanyId = 4,
                    CategoryId = 1,
                },
                new Employee()
                {
                    Id = 7,
                    Name = "Eve",
                    CompanyId = 5,
                    CategoryId = 2,
                },
                new Employee()
                {
                    Id = 8,
                    Name = "Frank",
                    CompanyId = 5,
                    CategoryId = 3,
                },
                new Employee()
                {
                    Id = 9,
                    Name = "Grace",
                    CompanyId = 6,
                    CategoryId = 1,
                },
                new Employee()
                {
                    Id = 10,
                    Name = "Henry",
                    CompanyId = 6,
                    CategoryId = 2,
                },
                new Employee()
                {
                    Id = 11,
                    Name = "Ivy",
                    CompanyId = 7,
                    CategoryId = 3,
                },
                new Employee()
                {
                    Id = 12,
                    Name = "Jack",
                    CompanyId = 7,
                    CategoryId = 1,
                },
                new Employee()
                {
                    Id = 13,
                    Name = "Kate",
                    CompanyId = 8,
                    CategoryId = 2,
                },
                new Employee()
                {
                    Id = 14,
                    Name = "Liam",
                    CompanyId = 8,
                    CategoryId = 3,
                },
                new Employee()
                {
                    Id = 15,
                    Name = "Mia",
                    CompanyId = 9,
                    CategoryId = 1,
                },
                new Employee()
                {
                    Id = 16,
                    Name = "Noah",
                    CompanyId = 9,
                    CategoryId = 2,
                },
                new Employee()
                {
                    Id = 17,
                    Name = "Olivia",
                    CompanyId = 10,
                    CategoryId = 3,
                },
                new Employee()
                {
                    Id = 18,
                    Name = "Peter",
                    CompanyId = 10,
                    CategoryId = 1,
                }
                );

            modelBuilder.Entity<Card>().HasData(
                new Card()
                {
                    Id = 1,
                    CardNumber = "1234123412341234",
                    Pin = BCrypt.Net.BCrypt.HashPassword("1234"),
                    Balance = 10000,
                    EmployeeId = 1
                },
                new Card()
                {
                    Id = 2,
                    CardNumber = "2345234523452345",
                    Pin = BCrypt.Net.BCrypt.HashPassword("2345"),
                    Balance = 20000,
                    EmployeeId = 2
                },
                new Card()
                {
                    Id = 3,
                    CardNumber = "3456345634563456",
                    Pin = BCrypt.Net.BCrypt.HashPassword("3456"),
                    Balance = 30000,
                    EmployeeId = 3
                },
                new Card()
                {
                    Id = 4,
                    CardNumber = "4567456745674567",
                    Pin = BCrypt.Net.BCrypt.HashPassword("4567"),
                    Balance = 40000,
                    EmployeeId = 4
                },
                new Card()
                {
                    Id = 5,
                    CardNumber = "5678567856785678",
                    Pin = BCrypt.Net.BCrypt.HashPassword("5678"),
                    Balance = 50000,
                    EmployeeId = 5
                },
                new Card()
                {
                    Id = 6,
                    CardNumber = "6789678967896789",
                    Pin = BCrypt.Net.BCrypt.HashPassword("6789"),
                    Balance = 60000,
                    EmployeeId = 6
                },
                new Card()
                {
                    Id = 7,
                    CardNumber = "7890789078907890",
                    Pin = BCrypt.Net.BCrypt.HashPassword("7890"),
                    Balance = 70000,
                    EmployeeId = 7
                },
                new Card()
                {
                    Id = 8,
                    CardNumber = "8901890189018901",
                    Pin = BCrypt.Net.BCrypt.HashPassword("8901"),
                    Balance = 80000,
                    EmployeeId = 8
                },
                new Card()
                {
                    Id = 9,
                    CardNumber = "9012901290129012",
                    Pin = BCrypt.Net.BCrypt.HashPassword("9012"),
                    Balance = 90000,
                    EmployeeId = 9
                }
                );

        }



        internal async Task<Company?> FindAsync(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}

