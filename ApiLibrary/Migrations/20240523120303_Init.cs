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
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
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
                    { 1, new DateTime(2024, 5, 23, 14, 2, 56, 74, DateTimeKind.Local).AddTicks(1463), null, "admin@benefitseller.com", false, "BenefitSeller", "$2a$11$8sFXIRFZJS4qO3MikehIr.eVq0cEEFlKkPDsDrlOakVHT9Los.Erq", "", "Admin", null },
                    { 2, new DateTime(2024, 5, 23, 14, 2, 56, 175, DateTimeKind.Local).AddTicks(4786), null, "info@techcorp.com", false, "TechCorp", "$2a$11$Tx36TrBxzv1TbGICKQmIq.aMOwzJW9hXO/PRKXWHK8sKkCiyDnNCq", "", "Company", null },
                    { 3, new DateTime(2024, 5, 23, 14, 2, 56, 278, DateTimeKind.Local).AddTicks(884), null, "contact@globalsolutions.com", false, "GlobalSolutions", "$2a$11$njSXh9sQEnJ4ILz3NjPbROZMCz.cYKT4W9M6pwwM1VQnjG7EwWP1e", "", "Company", null },
                    { 4, new DateTime(2024, 5, 23, 14, 2, 56, 380, DateTimeKind.Local).AddTicks(3391), null, "hello@innovatetech.com", false, "InnovateTech", "$2a$11$spDfwvDr.w8LMtLrYUhhVuBD35Csai7dwnFmih2XKx34R7FfbYXlm", "", "Company", null },
                    { 5, new DateTime(2024, 5, 23, 14, 2, 56, 483, DateTimeKind.Local).AddTicks(4129), null, "info@swiftenterprises.com", false, "SwiftEnterprises", "$2a$11$SIvry5jFyc7KyPtqkygVaOym1ZDUMN4HkjZzgBiBkCzvBLlU2jSze", "", "Company", null },
                    { 6, new DateTime(2024, 5, 23, 14, 2, 56, 594, DateTimeKind.Local).AddTicks(5023), null, "contact@alphainnovations.com", false, "AlphaInnovations", "$2a$11$k3l0BngEYA/20.QaodYK2.qyRh.OtPNIhVjrt0r68Zgg8V4R2.wRC", "", "Company", null },
                    { 7, new DateTime(2024, 5, 23, 14, 2, 56, 705, DateTimeKind.Local).AddTicks(8096), null, "info@globalnetworks.com", false, "GlobalNetworks", "$2a$11$F2eyoqVbAu3vHkpMWaF2jOjQ3A4Ks9oW/xszRbXuC3y9H/aqEzfxK", "", "Company", null },
                    { 8, new DateTime(2024, 5, 23, 14, 2, 56, 816, DateTimeKind.Local).AddTicks(998), null, "hello@techsavvy.com", false, "TechSavvy", "$2a$11$8KfH5ZrWTGn.bZzlFsHHqOeRgE9UXH8ejjxBYne029ardJV5RKaq.", "", "Company", null },
                    { 9, new DateTime(2024, 5, 23, 14, 2, 56, 926, DateTimeKind.Local).AddTicks(6233), null, "info@innovatehub.com", false, "InnovateHub", "$2a$11$NZyWk/dhoetx008s3bgAAepl44wXrA8E6cB5FMp9FVuHw19ufgfJO", "", "Company", null },
                    { 10, new DateTime(2024, 5, 23, 14, 2, 57, 38, DateTimeKind.Local).AddTicks(2411), null, "contact@alphatech.com", false, "AlphaTech", "$2a$11$0..JsgaAxQOP0Var2RRWJOtWAlHN3EV.8h5Kw/EKLgEW24NSDVTjq", "", "Company", null }
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
                    { 1, 10000m, "1234123412341234", 1, "$2a$11$7s.P.jf4AsCbImtAc6PHrOAvy7CY5utD1CdBZhL7v1U0xtRP39F5K" },
                    { 2, 20000m, "2345234523452345", 2, "$2a$11$3Z6eXNHC09ZH80Mc1ylXu.zT9spjQ7BDc2G9crnEd1VpL6uZU4.DO" },
                    { 3, 30000m, "3456345634563456", 3, "$2a$11$84GPa/OEi3GuXhWzKw6axOKva7ThCizKiZw3vNdjNoU/ebXwcSzXO" },
                    { 4, 40000m, "4567456745674567", 4, "$2a$11$zmN4bmKUI8QR84vXmNx/tOWmn8DnLdxs9ie9qV51YB3U4ZcIj3cEq" },
                    { 5, 50000m, "5678567856785678", 5, "$2a$11$WV9/qGn2IJNMUM3uNrkSAeUH4aTO0/GMH0YLG17/yBuXOaNZqRlHi" },
                    { 6, 60000m, "6789678967896789", 6, "$2a$11$6Q67R1MhYdKxNVaVxGbOo.tQtDRY21lRqObIEaK1f1hM8a2lxgKQy" },
                    { 7, 70000m, "7890789078907890", 7, "$2a$11$EwlgBWHdRv/g5ZlSDdTQTugIvoISV7X7DvHngWtOoaYCIRp1VluKO" },
                    { 8, 80000m, "8901890189018901", 8, "$2a$11$FsXXBCReE7r05zRZEJ42oexX0HqfyxSOAuxWhR7JCX9gAgCrsJPHm" },
                    { 9, 90000m, "9012901290129012", 9, "$2a$11$HMu9QpU4bEwX5.U.Ij460O4KNbcAIUmnYi86/WenceNFIRABSVroW" }
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
                name: "Transactions");

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
