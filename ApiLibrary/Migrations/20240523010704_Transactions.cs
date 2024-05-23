using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Transactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pin",
                value: "$2a$11$94PsOmiM9HZCslYFpYsfjugoSSoRK4ctEsVeEplUC4ojxvaoIhkIy");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Pin",
                value: "$2a$11$XTP6VlNJLmnpSTTOaPWwge5LFkMPrx4I2tFvFstB682CMB8deegvK");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pin",
                value: "$2a$11$A6uR/3hQ372uQBcgiWl1POASMCwRRV7Af4Uwq9zbb0O/9THM0eRB.");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "Pin",
                value: "$2a$11$qbFNaq1S.d8T2rPzceUoQepHdVzh3dsnhLrNvKwSu.ad8OHN5BdXK");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "Pin",
                value: "$2a$11$NX1GCbFw2LTpTIsTxwmXHuZiKSM/PjcYwZBhuWqgu9J/4lCr3qQT2");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "Pin",
                value: "$2a$11$/sMHybFoljfrKl44W9s9qOlgQ3FNuH2v/9NI51E07PCLjEbEjSTOm");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "Pin",
                value: "$2a$11$Jdo0yUzSTJrRAUX0P2fkJuKLayq7rIqG/4IY5boZfjXiIdogh2v0G");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "Pin",
                value: "$2a$11$TYTTUZ.V8IAxUqqDu4leY.wsJvettnNgTPqYsgujMSrxCxS8Tduti");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "Pin",
                value: "$2a$11$EdWxaMPMQGnYrc9QY88jyuFrROuOdt8eh.s4sqdNhTK7icbSPtBYO");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 2, 182, DateTimeKind.Local).AddTicks(334), "$2a$11$EX.XQDbKA4pCOpdfDNhTRO2l8AJvhrIF3d1n/CyIu2rayq2WzypGW" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 2, 293, DateTimeKind.Local).AddTicks(9997), "$2a$11$ChznQ2xR.XuqPTcLeVwQduYYM4jXM5h7HwmJ4flKa6n1EjHrjn2u6" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 2, 406, DateTimeKind.Local).AddTicks(4157), "$2a$11$3VzlnUR7b6EOcnUqaO4O3.YtKw/8rGMdaRji24fw364zmaPRUDtPK" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 2, 517, DateTimeKind.Local).AddTicks(2452), "$2a$11$iiccAu2XJzISQ3uL6rf5OeNyswLjE/M.sfQ43VbEOMBZGCnTdd2/W" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 2, 627, DateTimeKind.Local).AddTicks(4404), "$2a$11$5ye1zu8l2n.WNgFc0atq7OIY.ZvSQooHAvxJP3YMHl4g/hMkcBbxq" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 2, 737, DateTimeKind.Local).AddTicks(7129), "$2a$11$0bhc9MEg3xg4rwr1aF2Vjud5a3Ce0X8V3bTOCJtNUtuF2UbQ/l3lS" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 2, 848, DateTimeKind.Local).AddTicks(988), "$2a$11$ix6RH1kZ/OHOpCXE6gGKC.Qef8yjjU6RD2XDPwHPUYyJFUvYoqBoK" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 2, 958, DateTimeKind.Local).AddTicks(2608), "$2a$11$UC6KULpKWXdycKn.Jve2dezHSvKFIBGXkSMNtC2kma/f6NJnNMLq2" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 3, 68, DateTimeKind.Local).AddTicks(6919), "$2a$11$y5NVR7Ab1i/InALlohVcBewukVwyrNV8aoV3o7VLw2zd.fWGtVQOW" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 7, 3, 179, DateTimeKind.Local).AddTicks(1444), "$2a$11$kdjR2AKT92234kP04OTfJOdvsIxc094ue6bTE.EuaIdDVaBqWUN9u" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pin",
                value: "$2a$11$i0inhFkZ4xZ.rF15ycfvlupjefR0tg1olcVI23qdTWHiTx41qi0lC");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Pin",
                value: "$2a$11$2BLDJXYrnpJKUu8qt2Luyu3PBfknVMCRJ4xmzaBtKFi3/2u2DVY5q");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pin",
                value: "$2a$11$RyhF5XFfA6ufBuAGjHctOuWpIenRk9GJRIhwb7DFADfhsG4Pl0.Ke");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "Pin",
                value: "$2a$11$7whieWcv/HhsueKNh1jq..eiXu0fp1G.e2Zmrqp01qJbTg11s2Ziu");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "Pin",
                value: "$2a$11$Eg6ORw2OwcFD76hOphwHaugcxtEBnaudC9C7XfdnLvciR5ZS7Nk22");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "Pin",
                value: "$2a$11$mDiVEuyyq4p4h4dkHjVnmuOe6PKSp6pLjIM85F1Vo7yeLJXNU98gK");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "Pin",
                value: "$2a$11$fPr4DAeVZu/JTzFJ3PV.z.DBjXB05NG1SWsSCzsMI0XCpz9SOCDMe");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "Pin",
                value: "$2a$11$8MyuyX4ppypq2t9uauuGj.baaSsz6qHy5p/Hlaomp0ipPuo4uJPCO");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "Pin",
                value: "$2a$11$Lsj90y8ipKZH3qSU8b4V2OZ2naZag0LW1M/iIof5Y8jymL2edHSGW");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 2, 500, DateTimeKind.Local).AddTicks(3993), "$2a$11$MRgAywjdXA0BMFquxsBI3OujY0YdhSolfcmxLlgRi.4nWxjR4yRvq" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 2, 611, DateTimeKind.Local).AddTicks(117), "$2a$11$sRBtbFtD7QfqzEl1UEIc1eeZ7XrHc7lJ1UVs5DYf9.mUL8Zi2bD1m" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 2, 719, DateTimeKind.Local).AddTicks(8731), "$2a$11$QuRL/v1UzAu65V2yXiha0OksTSAC2LDtJB3WV/AZMKcj64Co6Tjca" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 2, 829, DateTimeKind.Local).AddTicks(7083), "$2a$11$QA.T1ndCX/6nhr954J0A3OX/RxFr8ICSeFc9RS161tOKTC6ZgGbE." });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 2, 939, DateTimeKind.Local).AddTicks(4346), "$2a$11$oRn6f4Or/hlGGV9BMdud7uP0J/iWtE5L/fxJYBCNnNlshm0zSqkRG" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 3, 49, DateTimeKind.Local).AddTicks(3572), "$2a$11$y.PArTEFfWr8oOGgUzv29e8v2weVRBaSB.HVRnAXgxjFAuwFlrAD." });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 3, 160, DateTimeKind.Local).AddTicks(2342), "$2a$11$f2PI3lPDr2OJxA9GcS046.Gzug0VK6HrgErjHbjegtuqdI4B7fTxy" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 3, 271, DateTimeKind.Local).AddTicks(7407), "$2a$11$u1RNBnJKTzThtb.d.x8kRetV61mUfdZ7NMaLshWx4/Do4CjXHlwPm" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 3, 384, DateTimeKind.Local).AddTicks(7004), "$2a$11$1ksZ.pTL8jRJvshryzghM.J2mLjKG4gOdC6lKXaD757UKRrFRAWzW" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 23, 2, 49, 3, 494, DateTimeKind.Local).AddTicks(4021), "$2a$11$hoz7GGyG6A1jv7kRXmGIlu2IcNKjMnNIdihdEMFceKOjz4LFtey.m" });
        }
    }
}
