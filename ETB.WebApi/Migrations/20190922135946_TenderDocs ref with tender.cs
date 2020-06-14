using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class TenderDocsrefwithtender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderDoc_Tenders_TenderId",
                table: "TenderDoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderDoc",
                table: "TenderDoc");

            migrationBuilder.RenameTable(
                name: "TenderDoc",
                newName: "TenderDocs");

            migrationBuilder.RenameIndex(
                name: "IX_TenderDoc_TenderId",
                table: "TenderDocs",
                newName: "IX_TenderDocs_TenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderDocs",
                table: "TenderDocs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderDocs_Tenders_TenderId",
                table: "TenderDocs",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderDocs_Tenders_TenderId",
                table: "TenderDocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderDocs",
                table: "TenderDocs");

            migrationBuilder.RenameTable(
                name: "TenderDocs",
                newName: "TenderDoc");

            migrationBuilder.RenameIndex(
                name: "IX_TenderDocs_TenderId",
                table: "TenderDoc",
                newName: "IX_TenderDoc_TenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderDoc",
                table: "TenderDoc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderDoc_Tenders_TenderId",
                table: "TenderDoc",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
