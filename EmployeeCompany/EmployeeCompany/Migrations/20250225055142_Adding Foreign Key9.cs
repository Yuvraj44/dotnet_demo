using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeCompany.Migrations
{
    /// <inheritdoc />
    public partial class AddingForeignKey9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeList_DepartmentId",
                table: "EmployeeList",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeList_DepartmentList_DepartmentId",
                table: "EmployeeList",
                column: "DepartmentId",
                principalTable: "DepartmentList",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeList_DepartmentList_DepartmentId",
                table: "EmployeeList");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeList_DepartmentId",
                table: "EmployeeList");
        }
    }
}
