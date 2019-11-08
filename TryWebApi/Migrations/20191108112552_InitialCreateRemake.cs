using Microsoft.EntityFrameworkCore.Migrations;

namespace TryWebApi.Migrations
{
    public partial class InitialCreateRemake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetServices_Users_UsersID",
                table: "GetServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetServices",
                table: "GetServices");

            migrationBuilder.DropIndex(
                name: "IX_GetServices_UsersID",
                table: "GetServices");

            migrationBuilder.DropColumn(
                name: "UsersID",
                table: "GetServices");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "GetServices",
                newName: "Service");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User",
                newName: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "ServiceID");

            migrationBuilder.CreateTable(
                name: "ServiceAssignment",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAssignment", x => new { x.UserID, x.ServiceID });
                    table.ForeignKey(
                        name: "FK_ServiceAssignment_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceAssignment_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAssignment_ServiceID",
                table: "ServiceAssignment",
                column: "ServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "GetServices");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "UsersID",
                table: "GetServices",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetServices",
                table: "GetServices",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_GetServices_UsersID",
                table: "GetServices",
                column: "UsersID");

            migrationBuilder.AddForeignKey(
                name: "FK_GetServices_Users_UsersID",
                table: "GetServices",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
