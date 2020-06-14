using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class AddingnewfieldstoTender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankCertificate",
                table: "Tenders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EMDPayableAt",
                table: "Tenders",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMDPaymentOption",
                table: "Tenders",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnEmployedEng",
                table: "Tenders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankCertificate",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "EMDPayableAt",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "EMDPaymentOption",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "UnEmployedEng",
                table: "Tenders");
        }
    }
}
