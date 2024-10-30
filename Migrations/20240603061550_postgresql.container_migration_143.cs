using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCoreMistakes.Migrations
{
    /// <inheritdoc />
    public partial class postgresqlcontainer_migration_143 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubSubModel",
                columns: new[] { "Id", "SubModelId", "SubSubInformation" },
                values: new object[,]
                {
                    { 6, 5, "SubSubmodel 6" },
                    { 7, 5, "SubSubmodel 7" },
                    { 8, 5, "SubSubmodel 8" },
                    { 9, 5, "SubSubmodel 9" },
                    { 10, 5, "SubSubmodel 10" }
                });

            migrationBuilder.InsertData(
                table: "SubSubSubModel",
                columns: new[] { "Id", "SubSubModelId", "SubSubSubInformation" },
                values: new object[,]
                {
                    { 6, 5, "SubSubmodel 6" },
                    { 7, 5, "SubSubmodel 7" },
                    { 8, 6, "SubSubmodel 8" },
                    { 9, 6, "SubSubmodel 9" },
                    { 10, 6, "SubSubmodel 10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubSubModel",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubSubModel",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubSubModel",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubSubModel",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubSubSubModel",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubSubSubModel",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubSubSubModel",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubSubSubModel",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubSubSubModel",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubSubModel",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
