using Microsoft.EntityFrameworkCore.Migrations;

namespace TryWebApi.Migrations
{
    public partial class addServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Users_UsersID",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "GetServices");

            migrationBuilder.RenameIndex(
                name: "IX_Service_UsersID",
                table: "GetServices",
                newName: "IX_GetServices_UsersID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetServices",
                table: "GetServices",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_GetServices_Users_UsersID",
                table: "GetServices",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetServices_Users_UsersID",
                table: "GetServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetServices",
                table: "GetServices");

            migrationBuilder.RenameTable(
                name: "GetServices",
                newName: "Service");

            migrationBuilder.RenameIndex(
                name: "IX_GetServices_UsersID",
                table: "Service",
                newName: "IX_Service_UsersID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Users_UsersID",
                table: "Service",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
