using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class ChangingattributestoCreatedByandModifiedby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "UserDetails",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "UserDetails",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserDetails",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Tenders",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Tenders",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_DistrictId",
                table: "UserDetails",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Districts_DistrictId",
                table: "UserDetails",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Districts_DistrictId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_DistrictId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "UserDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "UserDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "UserDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Tenders",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Tenders",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
