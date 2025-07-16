using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NopCommerceV1.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStoreId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsLetterSubscription_Email_StoreId",
                table: "NewsLetterSubscription");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "RewardPointsHistory");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "NewsLetterSubscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "RewardPointsHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "NewsLetterSubscription",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetterSubscription_Email_StoreId",
                table: "NewsLetterSubscription",
                columns: new[] { "Email", "StoreId" },
                unique: true,
                filter: "[StoreId] IS NOT NULL");
        }
    }
}
