using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockExchange_EGID.Server.Migrations
{
    /// <inheritdoc />
    public partial class ordersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("071f9755-64b3-4fcd-be97-1e765507f668"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("5f5dede2-7aa6-4b9b-a4c9-c15213bb1e1d"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("600f8b00-02a7-405c-8445-5b0e7e0dc35e"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("69bf6339-3d26-4227-b4dd-bd9cf0c44636"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("d84e9ada-eb89-43fa-a1c9-03c3be4b5f45"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quntity = table.Column<int>(type: "int", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3401183-8e64-4e5b-8fbd-8d0f3ede8a75",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27f19cdc-4c4b-4354-8277-e4045dee5a72", "AQAAAAIAAYagAAAAELauq5EpEk6ZF3PoXtu6YdAo50OXbhb5UxO89bX/RDRSX0zv1bDvd7rHYuN0+/hqjQ==", "AQAAAAIAAYagAAAAELauq5EpEk6ZF3PoXtu6YdAo50OXbhb5UxO89bX/RDRSX0zv1bDvd7rHYuN0+/hqjQ==", "5453883f-7e16-4e30-8eb2-c1826c0f2584" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc40d3cd-d322-484d-9593-51dc8c6fab1b",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ad50ecb-9f22-4c69-8e7c-4916cdee58fd", "AQAAAAIAAYagAAAAEF9RXF+GJu+G59w9Av4hsTQZ9K6eFP5Y+Mx5T1cU440kk2Il6glD180Xm+2j61XIHQ==", "AQAAAAIAAYagAAAAEF9RXF+GJu+G59w9Av4hsTQZ9K6eFP5Y+Mx5T1cU440kk2Il6glD180Xm+2j61XIHQ==", "959efc73-9eb4-4046-95af-0ddd4a061cea" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price", "Symbol" },
                values: new object[,]
                {
                    { new Guid("36700712-ad56-42df-ad6a-c983d25463ed"), "Apple Inc.", 150.25m, "AAPL" },
                    { new Guid("517d2130-15be-4fef-a146-931e829717c2"), "Microsoft Corporation", 300.00m, "MSFT" },
                    { new Guid("559e1e9a-a7f6-46e3-8ed0-e16d2a7ca790"), "Alphabet Inc.", 2800.45m, "GOOGL" },
                    { new Guid("c257b6b1-3ab7-4f4e-9d75-084665469011"), "Amazon.com Inc.", 3300.00m, "AMZN" },
                    { new Guid("d4fad452-9580-4d2e-b0a5-dc5ce40f3954"), "Tesla Inc.", 800.00m, "TSLA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("36700712-ad56-42df-ad6a-c983d25463ed"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("517d2130-15be-4fef-a146-931e829717c2"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("559e1e9a-a7f6-46e3-8ed0-e16d2a7ca790"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("c257b6b1-3ab7-4f4e-9d75-084665469011"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("d4fad452-9580-4d2e-b0a5-dc5ce40f3954"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3401183-8e64-4e5b-8fbd-8d0f3ede8a75",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a17f959b-c6ae-40e2-b828-50e7dabc9e56", "AQAAAAIAAYagAAAAEOVbsr6P9lO4hfHl8GMNlJXNKpwkl+k1LfDAPH8HfWc52PSX+Voq0aPQAD98gNYWgA==", "AQAAAAIAAYagAAAAEOVbsr6P9lO4hfHl8GMNlJXNKpwkl+k1LfDAPH8HfWc52PSX+Voq0aPQAD98gNYWgA==", "0ce9d060-09d7-425b-9234-2e404ea63616" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc40d3cd-d322-484d-9593-51dc8c6fab1b",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash", "SecurityStamp" },
                values: new object[] { "375706ab-6313-4181-9bae-b6e0bb943b89", "AQAAAAIAAYagAAAAEJVl5h53BxT8cX+mdm2v/k/XeMwow5tq9ly3KINpYj3J/hUntOkbcpaAKJEmKNu6yw==", "AQAAAAIAAYagAAAAEJVl5h53BxT8cX+mdm2v/k/XeMwow5tq9ly3KINpYj3J/hUntOkbcpaAKJEmKNu6yw==", "00fdecb5-e0ec-47f8-962f-ac4e4c22e10a" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price", "Symbol" },
                values: new object[,]
                {
                    { new Guid("071f9755-64b3-4fcd-be97-1e765507f668"), "Tesla Inc.", 800.00m, "TSLA" },
                    { new Guid("5f5dede2-7aa6-4b9b-a4c9-c15213bb1e1d"), "Alphabet Inc.", 2800.45m, "GOOGL" },
                    { new Guid("600f8b00-02a7-405c-8445-5b0e7e0dc35e"), "Microsoft Corporation", 300.00m, "MSFT" },
                    { new Guid("69bf6339-3d26-4227-b4dd-bd9cf0c44636"), "Amazon.com Inc.", 3300.00m, "AMZN" },
                    { new Guid("d84e9ada-eb89-43fa-a1c9-03c3be4b5f45"), "Apple Inc.", 150.25m, "AAPL" }
                });
        }
    }
}
