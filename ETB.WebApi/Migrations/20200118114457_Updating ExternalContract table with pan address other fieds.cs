using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class UpdatingExternalContracttablewithpanaddressotherfieds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ExternalContacts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "ExternalContacts",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Others",
                table: "ExternalContacts",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PAN",
                table: "ExternalContacts",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ExternalContacts");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "ExternalContacts");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "ExternalContacts");

            migrationBuilder.DropColumn(
                name: "PAN",
                table: "ExternalContacts");
        }
    }
}
