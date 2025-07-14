using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NopCommerceV1.Migrations
{
    /// <inheritdoc />
    public partial class Update_CustomerRole_AddFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "CustomerRoles",
                newName: "TaxExempt");

            migrationBuilder.AlterColumn<string>(
                name: "SystemName",
                table: "CustomerRoles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CustomerRoles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CustomerRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FreeShipping",
                table: "CustomerRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "CustomerRoles");

            migrationBuilder.DropColumn(
                name: "FreeShipping",
                table: "CustomerRoles");

            migrationBuilder.RenameColumn(
                name: "TaxExempt",
                table: "CustomerRoles",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "SystemName",
                table: "CustomerRoles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CustomerRoles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
