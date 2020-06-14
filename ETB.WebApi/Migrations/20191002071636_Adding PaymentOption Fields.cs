using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class AddingPaymentOptionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PayableAt",
                table: "Tenders",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentOption",
                table: "Tenders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayableAt",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "PaymentOption",
                table: "Tenders");
        }
    }
}
