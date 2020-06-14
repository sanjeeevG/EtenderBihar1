using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class TenderTablenullabletypechangedforIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Tenders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Tenders",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
