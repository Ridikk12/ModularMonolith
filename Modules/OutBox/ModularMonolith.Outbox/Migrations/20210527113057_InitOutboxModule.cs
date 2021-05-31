using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularMonolith.Outbox.Migrations
{
    public partial class InitOutboxModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "out");

            migrationBuilder.RenameTable(
                name: "OutBoxMessages",
                newName: "OutBoxMessages",
                newSchema: "out");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "OutBoxMessages",
                schema: "out",
                newName: "OutBoxMessages");
        }
    }
}
