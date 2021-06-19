using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheets.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_employees_UserId",
                table: "employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clients_UserId",
                table: "clients",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_clients_users_UserId",
                table: "clients",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_users_UserId",
                table: "employees",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_users_UserId",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_users_UserId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_UserId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_clients_UserId",
                table: "clients");
        }
    }
}
