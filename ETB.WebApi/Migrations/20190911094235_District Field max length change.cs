using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class DistrictFieldmaxlengthchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Districts_DistrictId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_DistrictId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "UserDetails");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "UserDetails",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Districts",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DistrictName",
                table: "Districts",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DistrictHQ",
                table: "Districts",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "UserDetails");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Districts",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DistrictName",
                table: "Districts",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DistrictHQ",
                table: "Districts",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
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
    }
}
