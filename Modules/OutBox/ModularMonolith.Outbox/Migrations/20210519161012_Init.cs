using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularMonolith.Outbox.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutBoxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SavedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SavedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutBoxMessages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutBoxMessages");
        }
    }
}
