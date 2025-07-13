using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NopCommerceV1.Migrations
{
    /// <inheritdoc />
    public partial class Create_GenericAttribute_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenericAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KeyGroup = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    key = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericAttribute", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenericAttribute_EntityId_KeyGroup_key",
                table: "GenericAttribute",
                columns: new[] { "EntityId", "KeyGroup", "key" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenericAttribute");
        }
    }
}
