using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektCSharp.Migrations
{
    public partial class AddDescriptionToClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Clients",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Clients");
        }
    }
}
