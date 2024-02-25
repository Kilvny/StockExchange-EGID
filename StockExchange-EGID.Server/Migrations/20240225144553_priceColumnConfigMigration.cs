using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockExchange_EGID.Server.Migrations
{
    /// <inheritdoc />
    public partial class priceColumnConfigMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3401183-8e64-4e5b-8fbd-8d0f3ede8a75",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaed40d8-163b-484f-981f-f776a6b55fc4", "AQAAAAIAAYagAAAAEKmciRWMTgtSBZTjvt6GaL51pPeWK4TrE3IsGjEBC+i7IPjJDsArKAsyoCv1X1eN2w==", "AQAAAAIAAYagAAAAEKmciRWMTgtSBZTjvt6GaL51pPeWK4TrE3IsGjEBC+i7IPjJDsArKAsyoCv1X1eN2w==", "d2c4c85f-b671-4f83-8b63-0947f14de4bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc40d3cd-d322-484d-9593-51dc8c6fab1b",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash", "SecurityStamp" },
                values: new object[] { "787fa131-0f2c-4eb6-b704-7b64a668ac3b", "AQAAAAIAAYagAAAAELA7RaT4msjruTPOOdvDwTF73YZpfCqdFdjLSW3FBxDeVRHicagUdb2B/lQflnNd8g==", "AQAAAAIAAYagAAAAELA7RaT4msjruTPOOdvDwTF73YZpfCqdFdjLSW3FBxDeVRHicagUdb2B/lQflnNd8g==", "9e1b3b14-1657-417d-8b9e-153108d44e55" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price", "Symbol" },
                values: new object[,]
                {
                    { new Guid("027d7559-f488-47be-a17f-2469c8e49d9f"), "Alphabet Inc.", 2800.45m, "GOOGL" },
                    { new Guid("36c2aea0-8d88-4a53-83e0-9cfb6ef1fbbd"), "Microsoft Corporation", 300.00m, "MSFT" },
                    { new Guid("96f48aa1-ea6c-430c-9283-abb356abbf80"), "Amazon.com Inc.", 3300.00m, "AMZN" },
                    { new Guid("f97188f6-dcb1-4596-a3c0-c3daae46b51e"), "Apple Inc.", 150.25m, "AAPL" },
                    { new Guid("febb3eed-33fd-48e4-a920-135c08e2d111"), "Tesla Inc.", 800.00m, "TSLA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("027d7559-f488-47be-a17f-2469c8e49d9f"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("36c2aea0-8d88-4a53-83e0-9cfb6ef1fbbd"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("96f48aa1-ea6c-430c-9283-abb356abbf80"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("f97188f6-dcb1-4596-a3c0-c3daae46b51e"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("febb3eed-33fd-48e4-a920-135c08e2d111"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

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
    }
}
