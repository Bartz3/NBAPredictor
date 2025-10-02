using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NBAPredictor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("007b9dca-a1da-47d7-afe9-0fc389b8bf4d"), null, "Admin", "ADMIN" },
                    { new Guid("b07874d0-4983-4bd8-9ce6-f09148abf73c"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("007b9dca-a1da-47d7-afe9-0fc389b8bf4d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b07874d0-4983-4bd8-9ce6-f09148abf73c"));
        }
    }
}
