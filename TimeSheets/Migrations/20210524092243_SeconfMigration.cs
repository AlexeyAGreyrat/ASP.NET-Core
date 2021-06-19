using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheets.Migrations
{
    public partial class SeconfMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Contracts_ContractId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Contracts_ContractId",
                table: "Sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Employees_EmployeeId",
                table: "Sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Invoice_InvoiceId",
                table: "Sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Services_ServiceId",
                table: "Sheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sheets",
                table: "Sheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Sheets",
                newName: "sheets");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "services");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "contracts");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "clients");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Sheets_ServiceId",
                table: "sheets",
                newName: "IX_sheets_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Sheets_InvoiceId",
                table: "sheets",
                newName: "IX_sheets_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Sheets_EmployeeId",
                table: "sheets",
                newName: "IX_sheets_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sheets_ContractId",
                table: "sheets",
                newName: "IX_sheets_ContractId");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "clients",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ContractId",
                table: "invoices",
                newName: "IX_invoices_ContractId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "contracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sheets",
                table: "sheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_services",
                table: "services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contracts",
                table: "contracts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clients",
                table: "clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_invoices",
                table: "invoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_contracts_ContractId",
                table: "invoices",
                column: "ContractId",
                principalTable: "contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sheets_contracts_ContractId",
                table: "sheets",
                column: "ContractId",
                principalTable: "contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sheets_employees_EmployeeId",
                table: "sheets",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sheets_invoices_InvoiceId",
                table: "sheets",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sheets_services_ServiceId",
                table: "sheets",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_contracts_ContractId",
                table: "invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sheets_contracts_ContractId",
                table: "sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_sheets_employees_EmployeeId",
                table: "sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_sheets_invoices_InvoiceId",
                table: "sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_sheets_services_ServiceId",
                table: "sheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sheets",
                table: "sheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_services",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contracts",
                table: "contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clients",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_invoices",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "clients");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "sheets",
                newName: "Sheets");

            migrationBuilder.RenameTable(
                name: "services",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "contracts",
                newName: "Contracts");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "invoices",
                newName: "Invoice");

            migrationBuilder.RenameIndex(
                name: "IX_sheets_ServiceId",
                table: "Sheets",
                newName: "IX_Sheets_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_sheets_InvoiceId",
                table: "Sheets",
                newName: "IX_Sheets_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_sheets_EmployeeId",
                table: "Sheets",
                newName: "IX_Sheets_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_sheets_ContractId",
                table: "Sheets",
                newName: "IX_Sheets_ContractId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Clients",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_invoices_ContractId",
                table: "Invoice",
                newName: "IX_Invoice_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sheets",
                table: "Sheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Contracts_ContractId",
                table: "Invoice",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Contracts_ContractId",
                table: "Sheets",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Employees_EmployeeId",
                table: "Sheets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Invoice_InvoiceId",
                table: "Sheets",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Services_ServiceId",
                table: "Sheets",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
