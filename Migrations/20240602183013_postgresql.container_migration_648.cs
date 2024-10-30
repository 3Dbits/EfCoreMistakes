using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCoreMistakes.Migrations
{
    /// <inheritdoc />
    public partial class postgresqlcontainer_migration_648 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubModel_SomeModel_SomeModelId",
                table: "SubModel");

            migrationBuilder.AlterColumn<int>(
                name: "SomeModelId",
                table: "SubModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SomeModel",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "SomeModel 1" },
                    { 2, "SomeModel 2" }
                });

            migrationBuilder.InsertData(
                table: "SubModel",
                columns: new[] { "Id", "Information", "SomeModelId" },
                values: new object[,]
                {
                    { 1, "Submodel 1", 1 },
                    { 2, "Submodel 2", 1 },
                    { 3, "Submodel 3", 2 },
                    { 4, "Submodel 4", 2 },
                    { 5, "Submodel 5", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SubModel_SomeModel_SomeModelId",
                table: "SubModel",
                column: "SomeModelId",
                principalTable: "SomeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubModel_SomeModel_SomeModelId",
                table: "SubModel");

            migrationBuilder.DeleteData(
                table: "SubModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubModel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubModel",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubModel",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SomeModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SomeModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "SomeModelId",
                table: "SubModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_SubModel_SomeModel_SomeModelId",
                table: "SubModel",
                column: "SomeModelId",
                principalTable: "SomeModel",
                principalColumn: "Id");
        }
    }
}
