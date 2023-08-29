using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaFermeWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLUs",
                columns: table => new
                {
                    Type = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLUs");
        }
    }
}
