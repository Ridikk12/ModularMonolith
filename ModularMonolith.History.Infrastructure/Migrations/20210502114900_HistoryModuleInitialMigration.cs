using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularMonolith.History.Infrastructure.Migrations
{
    public partial class HistoryModuleInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hi");

            migrationBuilder.CreateTable(
                name: "EntityHistories",
                schema: "hi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaisedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RaisedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityHistories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityHistories",
                schema: "hi");
        }
    }
}
