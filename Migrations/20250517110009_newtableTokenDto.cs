using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthwindAPI.Migrations
{
    /// <inheritdoc />
    public partial class newtableTokenDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TokenDtos",
                columns: table => new
                {
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TokenDtos");
        }
    }
}
