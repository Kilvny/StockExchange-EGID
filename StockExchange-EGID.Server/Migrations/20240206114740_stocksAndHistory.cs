using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockExchange_EGID.Server.Migrations
{
    /// <inheritdoc />
    public partial class stocksAndHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StocksHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksHistories", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "StocksHistories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3401183-8e64-4e5b-8fbd-8d0f3ede8a75",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e51acdba-966a-42b4-9e8e-c9fbd12bea0d", "AQAAAAIAAYagAAAAEML2vlK8SgUxL+wRrxRd7wBxuK3A9ZY+Hme6320e86DZRH2EG1WaEFg4YtEZYmQVfg==", "AQAAAAIAAYagAAAAEML2vlK8SgUxL+wRrxRd7wBxuK3A9ZY+Hme6320e86DZRH2EG1WaEFg4YtEZYmQVfg==", "1e882950-b16f-42a6-8d31-748c49db6c62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc40d3cd-d322-484d-9593-51dc8c6fab1b",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff5c8d21-c637-4d74-ad81-53e113776463", "AQAAAAIAAYagAAAAELb5Jo6dCSOts0NLZHpDhkL4+/Nkgq40nC4ihjbY/OUt3B8MOVhfrptg5PQ6eF3Tcg==", "AQAAAAIAAYagAAAAELb5Jo6dCSOts0NLZHpDhkL4+/Nkgq40nC4ihjbY/OUt3B8MOVhfrptg5PQ6eF3Tcg==", "2522c55d-9b6b-4aa1-b0d1-10b0773f57a5" });
        }
    }
}
