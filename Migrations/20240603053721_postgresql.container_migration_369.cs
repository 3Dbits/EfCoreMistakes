using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCoreMistakes.Migrations
{
    /// <inheritdoc />
    public partial class postgresqlcontainer_migration_369 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubSubModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubSubInformation = table.Column<string>(type: "text", nullable: false),
                    SubModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSubModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSubModel_SubModel_SubModelId",
                        column: x => x.SubModelId,
                        principalTable: "SubModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubSubSubModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubSubSubInformation = table.Column<string>(type: "text", nullable: false),
                    SubSubModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSubSubModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSubSubModel_SubSubModel_SubSubModelId",
                        column: x => x.SubSubModelId,
                        principalTable: "SubSubModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SubSubModel",
                columns: new[] { "Id", "SubModelId", "SubSubInformation" },
                values: new object[,]
                {
                    { 1, 1, "SubSubmodel 1" },
                    { 2, 2, "SubSubmodel 2" },
                    { 3, 3, "SubSubmodel 3" },
                    { 4, 4, "SubSubmodel 4" },
                    { 5, 5, "SubSubmodel 5" }
                });

            migrationBuilder.InsertData(
                table: "SubSubSubModel",
                columns: new[] { "Id", "SubSubModelId", "SubSubSubInformation" },
                values: new object[,]
                {
                    { 1, 1, "SubSubmodel 1" },
                    { 2, 2, "SubSubmodel 2" },
                    { 3, 3, "SubSubmodel 3" },
                    { 4, 4, "SubSubmodel 4" },
                    { 5, 5, "SubSubmodel 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubSubModel_SubModelId",
                table: "SubSubModel",
                column: "SubModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSubSubModel_SubSubModelId",
                table: "SubSubSubModel",
                column: "SubSubModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubSubSubModel");

            migrationBuilder.DropTable(
                name: "SubSubModel");
        }
    }
}
