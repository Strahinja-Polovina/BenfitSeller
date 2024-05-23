using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenefitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BenefitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyBenefits_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyBenefits_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMerchantsDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMerchantsDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyMerchantsDiscounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMerchantsDiscounts_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food and drinks" },
                    { 2, "Recreation" },
                    { 3, "Education" },
                    { 4, "Culture" },
                    { 5, "Travelling" },
                    { 6, "Shopping" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Standard Users" },
                    { 2, "Premium Users" },
                    { 3, "Platinum Users" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "IsDeleted", "Name", "Password", "RefreshToken", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 23, 2, 49, 2, 500, DateTimeKind.Local).AddTicks(3993), null, "admin@benefitseller.com", false, "BenefitSeller", "$2a$11$MRgAywjdXA0BMFquxsBI3OujY0YdhSolfcmxLlgRi.4nWxjR4yRvq", "", "Admin", null },
                    { 2, new DateTime(2024, 5, 23, 2, 49, 2, 611, DateTimeKind.Local).AddTicks(117), null, "info@techcorp.com", false, "TechCorp", "$2a$11$sRBtbFtD7QfqzEl1UEIc1eeZ7XrHc7lJ1UVs5DYf9.mUL8Zi2bD1m", "", "Company", null },
                    { 3, new DateTime(2024, 5, 23, 2, 49, 2, 719, DateTimeKind.Local).AddTicks(8731), null, "contact@globalsolutions.com", false, "GlobalSolutions", "$2a$11$QuRL/v1UzAu65V2yXiha0OksTSAC2LDtJB3WV/AZMKcj64Co6Tjca", "", "Company", null },
                    { 4, new DateTime(2024, 5, 23, 2, 49, 2, 829, DateTimeKind.Local).AddTicks(7083), null, "hello@innovatetech.com", false, "InnovateTech", "$2a$11$QA.T1ndCX/6nhr954J0A3OX/RxFr8ICSeFc9RS161tOKTC6ZgGbE.", "", "Company", null },
                    { 5, new DateTime(2024, 5, 23, 2, 49, 2, 939, DateTimeKind.Local).AddTicks(4346), null, "info@swiftenterprises.com", false, "SwiftEnterprises", "$2a$11$oRn6f4Or/hlGGV9BMdud7uP0J/iWtE5L/fxJYBCNnNlshm0zSqkRG", "", "Company", null },
                    { 6, new DateTime(2024, 5, 23, 2, 49, 3, 49, DateTimeKind.Local).AddTicks(3572), null, "contact@alphainnovations.com", false, "AlphaInnovations", "$2a$11$y.PArTEFfWr8oOGgUzv29e8v2weVRBaSB.HVRnAXgxjFAuwFlrAD.", "", "Company", null },
                    { 7, new DateTime(2024, 5, 23, 2, 49, 3, 160, DateTimeKind.Local).AddTicks(2342), null, "info@globalnetworks.com", false, "GlobalNetworks", "$2a$11$f2PI3lPDr2OJxA9GcS046.Gzug0VK6HrgErjHbjegtuqdI4B7fTxy", "", "Company", null },
                    { 8, new DateTime(2024, 5, 23, 2, 49, 3, 271, DateTimeKind.Local).AddTicks(7407), null, "hello@techsavvy.com", false, "TechSavvy", "$2a$11$u1RNBnJKTzThtb.d.x8kRetV61mUfdZ7NMaLshWx4/Do4CjXHlwPm", "", "Company", null },
                    { 9, new DateTime(2024, 5, 23, 2, 49, 3, 384, DateTimeKind.Local).AddTicks(7004), null, "info@innovatehub.com", false, "InnovateHub", "$2a$11$1ksZ.pTL8jRJvshryzghM.J2mLjKG4gOdC6lKXaD757UKRrFRAWzW", "", "Company", null },
                    { 10, new DateTime(2024, 5, 23, 2, 49, 3, 494, DateTimeKind.Local).AddTicks(4021), null, "contact@alphatech.com", false, "AlphaTech", "$2a$11$hoz7GGyG6A1jv7kRXmGIlu2IcNKjMnNIdihdEMFceKOjz4LFtey.m", "", "Company", null }
                });

            migrationBuilder.InsertData(
                table: "CompanyBenefits",
                columns: new[] { "Id", "BenefitId", "CompanyId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 3, 2 },
                    { 3, 5, 2 },
                    { 4, 4, 3 },
                    { 5, 3, 3 },
                    { 6, 1, 4 },
                    { 7, 5, 4 },
                    { 8, 6, 4 },
                    { 9, 2, 5 },
                    { 10, 6, 5 },
                    { 11, 4, 6 },
                    { 12, 3, 6 },
                    { 13, 2, 7 },
                    { 14, 1, 7 },
                    { 15, 1, 8 },
                    { 16, 4, 8 },
                    { 17, 3, 9 },
                    { 18, 2, 9 },
                    { 19, 1, 9 },
                    { 20, 3, 10 },
                    { 21, 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CategoryId", "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 2, "John Doe" },
                    { 2, 2, 2, "Jane Doe" },
                    { 3, 3, 3, "Alice" },
                    { 4, 2, 3, "Bob" },
                    { 5, 3, 3, "Charlie" },
                    { 6, 1, 4, "David" },
                    { 7, 2, 5, "Eve" },
                    { 8, 3, 5, "Frank" },
                    { 9, 1, 6, "Grace" },
                    { 10, 2, 6, "Henry" },
                    { 11, 3, 7, "Ivy" },
                    { 12, 1, 7, "Jack" },
                    { 13, 2, 8, "Kate" },
                    { 14, 3, 8, "Liam" },
                    { 15, 1, 9, "Mia" },
                    { 16, 2, 9, "Noah" },
                    { 17, 3, 10, "Olivia" },
                    { 18, 1, 10, "Peter" }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "BenefitId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Fast Food" },
                    { 2, 1, "Restoraunt" },
                    { 3, 2, "Gym" },
                    { 4, 2, "Boxing" },
                    { 5, 3, "School" },
                    { 6, 3, "University" },
                    { 7, 3, "Englis Course" },
                    { 8, 4, "Museum" },
                    { 9, 4, "Theater" },
                    { 10, 5, "Travel Agency" },
                    { 11, 6, "Shoe store" },
                    { 12, 6, "Clothing store" },
                    { 13, 6, "Bookstore" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Balance", "CardNumber", "EmployeeId", "Pin" },
                values: new object[,]
                {
                    { 1, 10000m, "1234123412341234", 1, "$2a$11$i0inhFkZ4xZ.rF15ycfvlupjefR0tg1olcVI23qdTWHiTx41qi0lC" },
                    { 2, 20000m, "2345234523452345", 2, "$2a$11$2BLDJXYrnpJKUu8qt2Luyu3PBfknVMCRJ4xmzaBtKFi3/2u2DVY5q" },
                    { 3, 30000m, "3456345634563456", 3, "$2a$11$RyhF5XFfA6ufBuAGjHctOuWpIenRk9GJRIhwb7DFADfhsG4Pl0.Ke" },
                    { 4, 40000m, "4567456745674567", 4, "$2a$11$7whieWcv/HhsueKNh1jq..eiXu0fp1G.e2Zmrqp01qJbTg11s2Ziu" },
                    { 5, 50000m, "5678567856785678", 5, "$2a$11$Eg6ORw2OwcFD76hOphwHaugcxtEBnaudC9C7XfdnLvciR5ZS7Nk22" },
                    { 6, 60000m, "6789678967896789", 6, "$2a$11$mDiVEuyyq4p4h4dkHjVnmuOe6PKSp6pLjIM85F1Vo7yeLJXNU98gK" },
                    { 7, 70000m, "7890789078907890", 7, "$2a$11$fPr4DAeVZu/JTzFJ3PV.z.DBjXB05NG1SWsSCzsMI0XCpz9SOCDMe" },
                    { 8, 80000m, "8901890189018901", 8, "$2a$11$8MyuyX4ppypq2t9uauuGj.baaSsz6qHy5p/Hlaomp0ipPuo4uJPCO" },
                    { 9, 90000m, "9012901290129012", 9, "$2a$11$Lsj90y8ipKZH3qSU8b4V2OZ2naZag0LW1M/iIof5Y8jymL2edHSGW" }
                });

            migrationBuilder.InsertData(
                table: "CompanyMerchantsDiscounts",
                columns: new[] { "Id", "CompanyId", "Discount", "MerchantId" },
                values: new object[,]
                {
                    { 1, 2, 10m, 1 },
                    { 2, 2, 15m, 10 },
                    { 3, 3, 20m, 5 },
                    { 4, 4, 25m, 10 },
                    { 5, 5, 30m, 13 },
                    { 6, 6, 35m, 6 },
                    { 7, 7, 40m, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_EmployeeId",
                table: "Cards",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBenefits_BenefitId",
                table: "CompanyBenefits",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBenefits_CompanyId",
                table: "CompanyBenefits",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMerchantsDiscounts_CompanyId",
                table: "CompanyMerchantsDiscounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMerchantsDiscounts_MerchantId",
                table: "CompanyMerchantsDiscounts",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CategoryId",
                table: "Employees",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_BenefitId",
                table: "Merchants",
                column: "BenefitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CompanyBenefits");

            migrationBuilder.DropTable(
                name: "CompanyMerchantsDiscounts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Benefits");
        }
    }
}
