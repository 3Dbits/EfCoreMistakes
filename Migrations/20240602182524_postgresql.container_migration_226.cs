using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCoreMistakes.Migrations
{
    /// <inheritdoc />
    public partial class postgresqlcontainer_migration_226 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SomeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Information = table.Column<string>(type: "text", nullable: false),
                    SomeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubModel_SomeModel_SomeModelId",
                        column: x => x.SomeModelId,
                        principalTable: "SomeModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubModel_SomeModelId",
                table: "SubModel",
                column: "SomeModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubModel");

            migrationBuilder.DropTable(
                name: "SomeModel");
        }
    }
}
