using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeCompany.Migrations
{
    /// <inheritdoc />
    public partial class Usertablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserCredentials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCredentials",
                table: "UserCredentials",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCredentials",
                table: "UserCredentials");

            migrationBuilder.RenameTable(
                name: "UserCredentials",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");
        }
    }
}
