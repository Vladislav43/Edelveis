using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kozariz.Edelveis.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordToUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UsersTable");
        }
    }
}
